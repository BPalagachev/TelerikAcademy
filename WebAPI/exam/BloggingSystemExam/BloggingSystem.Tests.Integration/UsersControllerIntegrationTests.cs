using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using System.Web.Http;
using System.Net;
using Newtonsoft.Json;
using System.Linq;
using BloggingSystem.Services.Controllers;
using BloggingSystem.Services.DataTransferObjects;

namespace BloggingSystem.Tests.Integration
{
    [TestClass]
    public class UsersControllerIntegrationTests
    {
        #region Initialization
        static TransactionScope tran;
        private InMemoryHttpServer httpServer;

        [TestInitialize]
        public void TestInit()
        {
            var type = typeof(UsersController);
            tran = new TransactionScope();

            var routes = new List<Route>
            {
                new Route(
                    "UsersRoute",
                    "api/users/{action}",
                    new
                    {
                        controller = "users",
                    }),
                new Route(
                    "DefaultApi",
                    "api/{controller}/{id}",
                    new
                    {
                        id = RouteParameter.Optional
                    })
                        
            };
            this.httpServer = new InMemoryHttpServer("http://localhost/", routes);
        }

        [TestCleanup]
        public void TearDown()
        {
            tran.Dispose();
        }
        #endregion

        #region RegisterTests

        [TestMethod]
        public void RegisterUser_ValidUser_ShouldBeLoggedIn()
        {
            var validUser = new UserRegisterDto()
            {
                AuthCode = new string('-', 40),
                NickName = "Valid NickName1 _.-",
                UserName = "ValidUser1._",
            };

            var response = httpServer.Post("api/users/register", validUser);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var loggedOnDto = JsonConvert.DeserializeObject<UserLoggedInDto>(contentString);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.IsNotNull(loggedOnDto.SessionKey);
            Assert.IsNotNull(loggedOnDto.NickName);
        }

        [TestMethod]
        public void RegisterUser_IncorrectdUser_ShouldReturnValidationErrorMessage()
        {
            var incorrectUser = new UserRegisterDto()
            {
                AuthCode = new string('-', 40),
                NickName = "InvalidNichName???",
                UserName = "Spaces Are Not Valid In UserName",
            };

            var response = httpServer.Post("api/users/register", incorrectUser);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var errorMsgDto = JsonConvert.DeserializeObject<ErrorMessageDto>(contentString);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.IsTrue(errorMsgDto.Message.StartsWith("User input validation failed. Errors:"));
        }

        [TestMethod]
        public void RegisterUser_IncorrectdUserUserNameTooLong_ShouldReturnValidationErrorMessage()
        {
            var incorrectUser = new UserRegisterDto()
            {
                AuthCode = new string('-', 40),
                NickName = new string('-', 40),
                UserName = "Spaces Are Not Valid In UserName",
            };

            var response = httpServer.Post("api/users/register", incorrectUser);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var errorMsgDto = JsonConvert.DeserializeObject<ErrorMessageDto>(contentString);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.IsTrue(errorMsgDto.Message.StartsWith("User input validation failed. Errors:"));
        }

        [TestMethod]
        public void RegisterUser_Null_ShouldReturnValidationErrorMessage()
        {
            object nullUser = null;

            var response = httpServer.Post("api/users/register", nullUser);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var errorMsgDto = JsonConvert.DeserializeObject<ErrorMessageDto>(contentString);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.IsTrue(errorMsgDto.Message.StartsWith("User input validation failed. Errors:"));
        }

        [TestMethod]
        public void RegisterUser_TryWithExistingUser_ShouldReturnValidationErrorMessage()
        {
            var registeredUser = new UserRegisterDto()
            {
                AuthCode = new string('-', 40),
                NickName = "Valid NickName1 _.-",
                UserName = "ValidUser1._",
            };

            httpServer.Post("api/users/register", registeredUser);

            var duplicatedUser = new UserRegisterDto()
            {
                AuthCode = new string('-', 40),
                NickName = "Valid NickName1 _.-",
                UserName = "ValidUser1._",
            };

            var response = httpServer.Post("api/users/register", duplicatedUser);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var errorMsgDto = JsonConvert.DeserializeObject<ErrorMessageDto>(contentString);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.IsTrue(errorMsgDto.Message == "User name or nickname is already taken");
        }

        #endregion 

        #region LogoutTests

        [TestMethod]
        public void Logout_LogoutValidUser_ShouldBeLoggedOut()
        {
            var loggedUser = this.RegisterValidUser();

            var sessionKey = loggedUser.SessionKey;
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = sessionKey;

            var response = httpServer.Put("api/users/logout", null, headers);

            var actionThatNeedAuthorizationResponse = httpServer.Put("api/users/logout", null, headers);
            var contentString = actionThatNeedAuthorizationResponse.Content.ReadAsStringAsync().Result;
            var errorMsg = JsonConvert.DeserializeObject<ErrorMessageDto>(contentString);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(HttpStatusCode.BadRequest, actionThatNeedAuthorizationResponse.StatusCode);
            Assert.AreEqual(errorMsg.Message, "User or password is incorrect.");
        }

        [TestMethod]
        public void Logout_LogoutInvalidUserSession_ShouldReturnInvalidUserError()
        {
            var sessionKey = "InvalidSessionKey";
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = sessionKey;

            var response = httpServer.Put("api/users/logout", null, headers);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var errorMsg = JsonConvert.DeserializeObject<ErrorMessageDto>(contentString);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual(errorMsg.Message, "User or password is incorrect.");
        }

        [TestMethod]
        public void Logout_LogoutUserWittInvalidSessionKey_ShouldStayLoggedIn()
        {
            var loggedUser = this.RegisterValidUser();

            var invalidSessionKey = "InvalidSessionKey";
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = invalidSessionKey;

            var invalidLogOut = httpServer.Put("api/users/logout", null, headers);
            var contentString = invalidLogOut.Content.ReadAsStringAsync().Result;
            var errorMsg = JsonConvert.DeserializeObject<ErrorMessageDto>(contentString);

            var validHeader = new Dictionary<string, string>();
            validHeader["X-sessionKey"] = loggedUser.SessionKey;
            var actionThatNeedAuthorizationResponse = httpServer.Put("api/users/logout", null, validHeader);
            
            // failed due to invalid sessionKey
            Assert.AreEqual(HttpStatusCode.BadRequest, invalidLogOut.StatusCode);
            Assert.AreEqual(errorMsg.Message, "User or password is incorrect.");

            // Perform operation that need session key => stayed logged in
            Assert.AreEqual(HttpStatusCode.OK, actionThatNeedAuthorizationResponse.StatusCode);

        }

        [TestMethod]
        public void Logout_LogoutUserWithNullSessionKey_ShouldStayLoggedIn()
        {
            var loggedUser = this.RegisterValidUser();

            string invalidSessionKey = null ;
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = invalidSessionKey;

            var invalidLogOut = httpServer.Put("api/users/logout", null, headers);
            var contentString = invalidLogOut.Content.ReadAsStringAsync().Result;
            var errorMsg = JsonConvert.DeserializeObject<ErrorMessageDto>(contentString);

            var validHeader = new Dictionary<string, string>();
            validHeader["X-sessionKey"] = loggedUser.SessionKey;
            var actionThatNeedAuthorizationResponse = httpServer.Put("api/users/logout", null, validHeader);

            // failed due to null sessionKey
            Assert.AreEqual(HttpStatusCode.BadRequest, invalidLogOut.StatusCode);
            Assert.AreEqual(errorMsg.Message, "User or password is incorrect.");

            // Perform operation that need session key => stayed logged in
            Assert.AreEqual(HttpStatusCode.OK, actionThatNeedAuthorizationResponse.StatusCode);
        }

        #endregion

        #region helpMethods

        private UserLoggedInDto RegisterValidUser()
        {
            var validUser = new UserRegisterDto()
            {
                AuthCode = new string('-', 40),
                NickName = "ValidNickName",
                UserName = "ValidUserName",
            };

            var response = httpServer.Post("api/users/register", validUser);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var loggedOn = JsonConvert.DeserializeObject<UserLoggedInDto>(contentString);
            return loggedOn;
        }

        #endregion
    }
}
