using ApiAutomation.Json_Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ApiAutomation
{
    [TestClass]
    public class UnitTest1
    {
        private static string BaseUri = "https://jsonplaceholder.typicode.com";

        private RestClient GetAllRestClient = new RestClient();

        private RestClient GetRestClient = new RestClient();

        /// <summary>
        ///     Verifies that values returned by get to do by id are correct.
        ///     https://jsonplaceholder.typicode.com/todos/1 
        /// </summary>
        [TestCategory("API")]
        [TestMethod]
        public void VerifyGetToDoById()
        {
            var restGetAllRequest = new RestRequest($"{BaseUri}/todos/");

            var allToDos = GetAllRestClient.Get<List<ToDosJsonModel>>(restGetAllRequest).Data;

            foreach (var toDoExpected in allToDos)
            {
                var restGetRequest = new RestRequest($"{BaseUri}/todos/{toDoExpected.Id}");
                var toDoActual = GetRestClient.Get<ToDosJsonModel>(restGetRequest).Data;

                Assert.AreEqual(toDoExpected.Id, toDoActual.Id, $"Incorrect to do id is retrieved for to do id {toDoExpected.Id}");
                Assert.AreEqual(toDoExpected.UserId, toDoActual.UserId, $"Incorrect user id is retrieved for to do id {toDoExpected.Id}");
                Assert.AreEqual(toDoExpected.Title, toDoActual.Title, $"Incorrect title is retrieved for to do id {toDoExpected.Id}");
                Assert.AreEqual(toDoExpected.Completed, toDoActual.Completed, $"Incorrect completed value is retrieved for to do id {toDoExpected.Id}");
            }

        }

        /// <summary>
        ///     Verifies get comments per post.
        ///         If there's comments -> Verify that post id, comment id and email are not empty
        ///         If there are no comments -> Verify correct http status
        ///         Otherwise, return failure
        ///     https://jsonplaceholder.typicode.com/posts/1/comments 
        /// </summary>
        [TestCategory("API")]
        [TestMethod]
        public void VerifyGetCommentPerPostById()
        {
            var restGetAllPostsRequest = new RestRequest($"{BaseUri}/posts/");

            var allPosts = GetAllRestClient.Get<List<PostJsonModel>>(restGetAllPostsRequest).Data;

            foreach (var allPostExpected in allPosts)
            {
                var restGetCommentsPerPostRequest = new RestRequest($"{BaseUri}/posts/{allPostExpected.Id}/comments");
                var commentActual = GetRestClient.Get<List<CommentJsonModel>>(restGetCommentsPerPostRequest);

                if (commentActual.StatusCode == HttpStatusCode.NoContent || commentActual.StatusCode == HttpStatusCode.NotFound)
                {
                    Assert.IsTrue(null == commentActual.Data, $"Post id {allPostExpected.Id} has returned 204 or 404 but returned a value");
                }
                else if (commentActual.StatusCode == HttpStatusCode.OK)
                {
                    Assert.IsTrue(commentActual.Data.All(i => i.PostId == allPostExpected.Id), $"One comment on Post id is incorrect");
                    Assert.IsTrue(commentActual.Data.All(i => i.Id > 0), $"One comment on Post id {allPostExpected.Id} has returned a non-integer comment id ");
                    Assert.IsTrue(commentActual.Data.All(i => !string.IsNullOrEmpty(i.Email)), $"One comment on Post id {allPostExpected.Id} has has empty email");
                }
                else
                {
                    Assert.IsTrue(false, $"Issue when trying to retrieve data for post id {allPostExpected.Id}. Http status = {commentActual.StatusCode}");
                }
            }
        }


        /// <summary>
        ///     Verifies that get post.
        ///         Invalid post id returnd 404 not found
        ///     https://jsonplaceholder.typicode.com/posts/a
        /// </summary>
        [TestCategory("API")]
        [TestMethod]
        public void VerifyGetInvalidPostId()
        {
            var restGetAllPostsRequest = new RestRequest($"{BaseUri}/posts/a");

            var getPostReposonse = GetAllRestClient.Get(restGetAllPostsRequest);

            Assert.IsTrue(getPostReposonse.StatusCode == HttpStatusCode.NotFound, $"Incorrect http status returned for a postid = 'a' ");
        }
    }
}
