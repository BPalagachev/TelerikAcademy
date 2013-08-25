using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http.Routing;
using System.Web.Http.Hosting;
using System.Web.Http.Controllers;
using Telerik.JustMock;
using Students.Repositories;
using Students.Models;
using Students.Services.Controllers;
using Students.Services.DataTransferObjects;

namespace Students.Services.Tests.Controllers
{
    [TestClass]
    public class StudentsControllerTests
    {
        private void SetupController(ApiController controller)
        {
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/students");
            var route = config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            var routeData = new HttpRouteData(route);
            routeData.Values.Add("id", RouteParameter.Optional);
            routeData.Values.Add("controller", "students");
            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            controller.Request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;
        }

        [TestMethod]
        public void Add_WhenNameIsValid_ShouldAddTheStudent()
        {
            bool isItemAdded = false;
            var repository = Mock.Create<IRepository>();

            var studentsModel = new StudentDto()
            {
                LastName = "new student", 
                Grade = 10
            };

            var studentEntity = new Student()
            {
                Id = 1,
                LastName = studentsModel.LastName,
                Grade = studentsModel.Grade
            };

            Mock.Arrange(() => repository.Add(Arg.IsAny<Student>()))
                .DoInstead(() => isItemAdded = true)
                .Returns(studentEntity);

            var controller = new StudentsController(repository);
            SetupController(controller);

            controller.Post(studentsModel);

            Assert.IsTrue(isItemAdded);

        }

        [TestMethod]
        public void GetAll()
        {
            var studentToAdd = new Student()
            {
                LastName = "ToAdd",
                Grade = 10
            };

            List<Student> studentEntities = new List<Student>();
            studentEntities.Add(studentToAdd);

            var repository = Mock.Create<IRepository>();
            Mock.Arrange(() => repository.All<Student>()).Returns(() => studentEntities.AsQueryable());

            var a = repository.All<Student>();
            var controller = new StudentsController(repository);
            SetupController(controller);
            var all = controller.Get().ToList();
            Assert.IsTrue(all.Count() == 1);
        }
    }
}
