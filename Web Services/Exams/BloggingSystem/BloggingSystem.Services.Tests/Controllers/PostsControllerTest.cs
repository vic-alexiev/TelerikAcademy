using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BloggingSystem.Services;
using BloggingSystem.Services.Controllers;
using System.Transactions;
using BloggingSystem.Services.Models;
using Newtonsoft.Json;
using System.Net;

namespace BloggingSystem.Services.Tests.Controllers
{
    [TestClass]
    public class PostsControllerTest
    {
        private TransactionScope scope;
        private InMemoryHttpServer httpServer;

        [TestInitialize]
        public void TestInit()
        {

            var type = typeof(UsersController);
            scope = new TransactionScope();

            var routes = new List<Route>
            {
                new Route(
                    "TagsApi",
                    "api/tags/{tagId}/posts",
                    new
                    {
                        controller = "tags",
                        action = "posts"
                    }),

                new Route(
                    "PostsApi",
                    "api/posts/{postId}/comment",
                    new
                    {
                        controller = "posts",
                        action = "comment"
                    }),

                new Route(
                    "UsersApi",
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
            scope.Dispose();
        }

        [TestMethod]
        public void TestCreateValidPost_ShouldReturnOK()
        {
            var testPost = new CreatePostDto
            {
                Title = "NEW POST",
                Text = "this is just a test post",
                Tags = new string[] { "post" }
            };

            var testUser = new UserDto
            {
                Username = "peter_petroff",
                DisplayName = "Peter Petroff",
                AuthCode = "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e"
            };

            var response = httpServer.Post("api/users/register", testUser);

            string contentString = response.Content.ReadAsStringAsync().Result;
            var loggedUser = JsonConvert.DeserializeObject<LoggedUserDto>(contentString);

            var headers = new Dictionary<string, string>();
            headers["X-SessionKey"] = loggedUser.SessionKey;

            var createPostResponse = httpServer.Post("api/posts", testPost, headers);

            string resultString = createPostResponse.Content.ReadAsStringAsync().Result;
            var createdPost = JsonConvert.DeserializeObject<CreatePostDto>(resultString);

            Assert.AreEqual(HttpStatusCode.Created, createPostResponse.StatusCode);
            Assert.AreEqual(testPost.Title, createdPost.Title);
            Assert.AreEqual(testPost.Text, createdPost.Text);
            Assert.IsNotNull(createdPost.Id);
        }
    }
}
