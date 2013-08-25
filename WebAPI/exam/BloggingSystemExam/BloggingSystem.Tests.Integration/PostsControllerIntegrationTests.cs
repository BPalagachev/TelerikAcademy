using BloggingSystem.Services.Controllers;
using BloggingSystem.Services.DataTransferObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Transactions;
using System.Web.Http;

namespace BloggingSystem.Tests.Integration
{
    [TestClass]
    public class PostsControllerIntegrationTests
    {
        #region Initialization
        static TransactionScope tran;
        private InMemoryHttpServer httpServer;

        [TestInitialize]
        public void TestInit()
        {
            var type = typeof(PostsController);
            tran = new TransactionScope();

            var routes = new List<Route>
            {
                new Route(
                    "PostsLeaveCommentsRoute",
                    "api/posts/{postId}/comment",
                    new
                    {
                        controller = "posts", 
                        action = "LeaveComment"
                    }),
                new Route(
                    "TagsGetPostsRoute",
                    "api/tags/{tagId}/posts",
                    new
                    {
                        controller = "tags",
                        action = "GetPosts"
                    }),
                new Route(
                    "UsersRoute",
                    "api/users/{action}",
                    new
                    {
                        controller = "users"
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

        #region CreateTests
        [TestMethod]
        public void CreatePost_ValidPostWithoutTags_ShouldBeAdded()
        {
            var user = RegisterValidUser();

            var sessionKey = user.SessionKey;
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = sessionKey;

            var validPost = new PostCreateDto()
             {
                 Text = "valid text",
                 Title = "valid title"
             };

            var response = httpServer.Post("api/posts", validPost, headers);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var responseObject = JsonConvert.DeserializeObject<PostCreateResponseDto>(contentString);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.AreEqual(responseObject.Title, validPost.Title);
            Assert.IsTrue(responseObject.Id > 0);
        }

        [TestMethod]
        public void CreatePost_ValidPostWithoutTags_TagsFromTitleShouldBeAdded()
        {
            var user = RegisterValidUser();

            var sessionKey = user.SessionKey;
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = sessionKey;

            var validPost = new PostCreateDto()
            {
                Text = "TagsInTitle Test",
                Title = "TagsInTitle Test"
            };


            var createPostResponse = httpServer.Post("api/posts", validPost, headers);
            var contentString = createPostResponse.Content.ReadAsStringAsync().Result;
            var createPostResponseObject = JsonConvert.DeserializeObject<PostCreateResponseDto>(contentString);

            var getPostByTagsName = httpServer.Get("api/posts", headers);

            Assert.AreEqual(HttpStatusCode.Created, createPostResponse.StatusCode);
            Assert.AreEqual(createPostResponseObject.Title, validPost.Title);
            Assert.IsTrue(createPostResponseObject.Id > 0);
            Assert.AreEqual(HttpStatusCode.OK, getPostByTagsName.StatusCode);
            Assert.IsNotNull(getPostByTagsName.Content);

        }

        [TestMethod]
        public void CreatePost_ValidPostWithTags_ShouldBeAdded()
        {
            var user = RegisterValidUser();

            var sessionKey = user.SessionKey;
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = sessionKey;

            var validPost = new PostCreateDto()
            {
                Text = "valid text",
                Title = "valid title",
                Tags = new string[] { "tag1", "tag2", "tag3" }
            };


            var response = httpServer.Post("api/posts", validPost, headers);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var responseObject = JsonConvert.DeserializeObject<PostCreateResponseDto>(contentString);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.AreEqual(responseObject.Title, validPost.Title);
            Assert.IsTrue(responseObject.Id > 0);

        }


        [TestMethod]
        public void CreatePost_NullPost_ShoudlReturnValidationError()
        {
            var user = RegisterValidUser();

            var sessionKey = user.SessionKey;
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = sessionKey;

            PostCreateDto nullPost = null;

            var response = httpServer.Post("api/posts", nullPost, headers);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var responseObject = JsonConvert.DeserializeObject<ErrorMessageDto>(contentString);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual(responseObject.Message, "Cannot add empty post.");

        }

        #endregion

        #region PostsByTagTests
        [TestMethod]
        public void GetByTags_ValidPostWithoutTags_ShoudReturnTagsFromTitle()
        {
            var user = RegisterValidUser();

            var sessionKey = user.SessionKey;
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = sessionKey;

            var validPost = new PostCreateDto()
            {
                Text = "Valid Text",
                Title = "TagsInTitle Test"
            };

            httpServer.Post("api/posts", validPost, headers);

            var response = httpServer.Get("api/posts?tags=TagsInTitle,Test", headers);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var postsByTags = JsonConvert.DeserializeObject<List<PostDto>>(contentString);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            foreach (var item in postsByTags)
            {
                Assert.IsTrue(item.Tags.Contains("tagsintitle"));
                Assert.IsTrue(item.Tags.Contains("test"));
            }
        }

        [TestMethod]
        public void GetByTags_ValidPostWithTags_ShoudReturnTagsFromTitleAndTags()
        {
            var user = RegisterValidUser();

            var sessionKey = user.SessionKey;
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = sessionKey;

            var validPost = new PostCreateDto()
            {
                Text = "Valid Text",
                Title = "tagsintitle test",
                Tags = new string[] { "tag1", "tags2" }
            };

            httpServer.Post("api/posts", validPost, headers);

            var response = httpServer.Get("api/posts?tags=TagsInTitle,Test", headers);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var postsByTags = JsonConvert.DeserializeObject<List<PostDto>>(contentString);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            foreach (var item in postsByTags)
            {
                Assert.IsTrue(item.Tags.Contains("tagsintitle"));
                Assert.IsTrue(item.Tags.Contains("test"));
                Assert.IsTrue(item.Tags.Contains("tag1"));
                Assert.IsTrue(item.Tags.Contains("tags2"));
            }

        }

        [TestMethod]
        public void GetByTags_MatchNothing_ShouldReturnEmptyColletion()
        {
            var user = RegisterValidUser();

            var sessionKey = user.SessionKey;
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = sessionKey;

            var response = httpServer.Get("api/posts?tags=TagsThatIsSurelyNotInTheDabaBaseShouldBeLong", headers);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var postsByTags = JsonConvert.DeserializeObject<List<PostDto>>(contentString);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsTrue(postsByTags.Count == 0);
        }

        [TestMethod]
        public void GetByTags_TagsStrEmpty_ShouldReturnValidationError()
        {
            var user = RegisterValidUser();

            var sessionKey = user.SessionKey;
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = sessionKey;

            var response = httpServer.Get("api/posts?tags=", headers);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var errorMsg = JsonConvert.DeserializeObject<ErrorMessageDto>(contentString);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual(errorMsg.Message, "Tags string cannot be null or empry.");
        }
        #endregion

        #region LeaveCommentTest

        [TestMethod]
        public void LeaveComment_ValidComment_ShouldBeAddedToPost()
        {
            var user = this.RegisterValidUser();
            var post = this.CreateValidPost(user.SessionKey);

            var validComment = new PostLeaveCommentDto()
            {
                Text = "Some Valid Text"
            };

            var url = string.Format("api/posts/{0}/comment", post.Id);

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = user.SessionKey;

            var response = httpServer.Put(url, validComment, headers);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void LeaveComment_AddMultipleComments_ShouldBeAddedToPost()
        {
            var user = this.RegisterValidUser();
            var post = this.CreateValidPost(user.SessionKey);

            var validComment = new PostLeaveCommentDto()
            {
                Text = "Some Valid Text"
            };
            var url = string.Format("api/posts/{0}/comment", post.Id);
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = user.SessionKey;

            for (int i = 0; i < 10; i++)
            {
                var response = httpServer.Put(url, validComment, headers);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [TestMethod]
        public void LeaveComment_NullComment_ShouldReturnValidationError()
        {
            var user = this.RegisterValidUser();
            var post = this.CreateValidPost(user.SessionKey);

            PostLeaveCommentDto nullComment = null;
            var url = string.Format("api/posts/{0}/comment", post.Id);
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = user.SessionKey;


            var response = httpServer.Put(url, nullComment, headers);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var errorMsg = JsonConvert.DeserializeObject<ErrorMessageDto>(contentString);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual(errorMsg.Message, "Cannot add empry comments.");
        }

        [TestMethod]
        public void LeaveComment_InvalidCommentWithEmptyText_ShouldReturnValidationError()
        {
            var user = this.RegisterValidUser();
            var post = this.CreateValidPost(user.SessionKey);

            PostLeaveCommentDto invalidCommentText = new PostLeaveCommentDto()
            {
                Text = string.Empty
            };
            var url = string.Format("api/posts/{0}/comment", post.Id);
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = user.SessionKey;


            var response = httpServer.Put(url, invalidCommentText, headers);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var errorMsg = JsonConvert.DeserializeObject<ErrorMessageDto>(contentString);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual(errorMsg.Message, "Cannot add empry comments.");

        }

        [TestMethod]
        public void LeaveComment_AddCommentToNonExistingPost_ShouldReturnValidationError()
        {
            var user = this.RegisterValidUser();

            var validComment = new PostLeaveCommentDto()
            {
                Text = "Some Valid Text"
            };
            var url = string.Format("api/posts/{0}/comment", 0);
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = user.SessionKey;

            var response = httpServer.Put(url, validComment, headers);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var errorMsg = JsonConvert.DeserializeObject<ErrorMessageDto>(contentString);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual(errorMsg.Message, "No post with that id exists.");

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

        private PostCreateResponseDto CreateValidPost(string sessionKey)
        {
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = sessionKey;

            var validPost = new PostCreateDto()
            {
                Text = "valid text",
                Title = "valid title"
            };


            var response = httpServer.Post("api/posts", validPost, headers);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var responseObject = JsonConvert.DeserializeObject<PostCreateResponseDto>(contentString);

            return responseObject;
        }

        #endregion
    }
}
