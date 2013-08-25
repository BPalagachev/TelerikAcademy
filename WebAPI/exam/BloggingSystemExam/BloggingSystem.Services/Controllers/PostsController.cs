using BloggingSystem.DataLayer;
using BloggingSystem.Models;
using BloggingSystem.Services.Attributes;
using BloggingSystem.Services.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Transactions;
using System.Web.Http;
using System.Web.Http.ValueProviders;

namespace BloggingSystem.Services.Controllers
{
    public class PostsController : BaseApiController
    {
        private BloggingSystemContext dbContext = new BloggingSystemContext();

        public IQueryable<PostDto> GetAll([ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var operationResult = this.PerformOperationAndHandleExceptions(() =>
            {
                bool isAuthorized = this.dbContext.Users.Any(x => x.SessionKey == sessionKey);
                if (!isAuthorized)
                {
                    throw new InvalidOperationException("Not authorized to view this page");
                }

                var posts = this.dbContext.Posts
                    .OrderByDescending(x => x.PostDate)
                    .Select(PostDto.FromPost);
                return posts;
            });

            return operationResult;
        }

        public IQueryable<PostDto> GetByKeyword(string keyword,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var postByKeyword = this.GetAll(sessionKey)
                .Where(p => p.Title.Contains(keyword));

            return postByKeyword;
        }

        public IQueryable<PostDto> GetPage(int page, int count,
           [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            int skip = page * count;
            int take = (page + 1) * count;

            var allPosts = this.GetAll(sessionKey)
               .Skip(skip)
                .Take(take);

            return allPosts;
        }

        public IQueryable<PostDto> GetByTags(string tags,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            if (string.IsNullOrEmpty(tags))
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Tags string cannot be null or empry." );
                throw new HttpResponseException(errResponse);
            }

            var allTags = tags.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var posts = this.GetAll(sessionKey)
                .Where(p => p.Tags.All(t => allTags.Contains(t.ToLower())));

            return posts;
        }

        [HttpPost]
        [ActionName("create")]
        public HttpResponseMessage CreateNewPost(PostCreateDto creationInfo,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var operationResult = this.PerformOperationAndHandleExceptions(() =>
            {
                var tran = new TransactionScope();
                using (tran)
                {
                    if (creationInfo == null)
                    {
                         throw new ArgumentException("Cannot add empty post.");
                    }

                    var user = this.dbContext.Users.FirstOrDefault(x => x.SessionKey == sessionKey);
                    if (user == null)
                    {
                        throw new InvalidOperationException("Not authorized to view this page");
                    }

                    var newPost = new Post()
                    {
                        User = user,
                        PostDate = DateTime.Now,
                        Title = creationInfo.Title,
                        Text = creationInfo.Text,
                    };

                    var titleTags = creationInfo.Title.Split(new char[] { ' ', ',', '.', ':' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Trim());
                    CreateOrLoadTags(titleTags, newPost);
                    CreateOrLoadTags(creationInfo.Tags, newPost);

                    this.dbContext.Posts.Add(newPost);
                    this.dbContext.SaveChanges();

                    var createPostResponse = new PostCreateResponseDto()
                    {
                        Id = newPost.Id,
                        Title = newPost.Title
                    };

                    tran.Complete();
                    var response = Request.CreateResponse(HttpStatusCode.Created, createPostResponse);
                    return response;
                }
            });

            return operationResult;
        }

        [HttpPut]
        public HttpResponseMessage LeaveComment(int postId, PostLeaveCommentDto creationInfo,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var operationResult = this.PerformOperationAndHandleExceptions(() =>
            {
                if (creationInfo == null || string.IsNullOrEmpty(creationInfo.Text))
                {
                    throw new InvalidOperationException("Cannot add empry comments.");
                }

                var user = this.dbContext.Users.FirstOrDefault(x => x.SessionKey == sessionKey);
                if (user == null)
                {
                    throw new InvalidOperationException("Not authorized to view this page.");
                }

                var post = this.dbContext.Posts.FirstOrDefault(x => x.Id == postId);
                if (post == null)
                {
                    throw new InvalidOperationException("No post with that id exists.");
                }

                var newComment = new Comment()
                {
                    User = user,
                    CommentDate = DateTime.Now,
                    Text = creationInfo.Text
                };

                post.Comments.Add(newComment);
                dbContext.SaveChanges();

                var response = Request.CreateResponse(HttpStatusCode.OK);
                return response;
            });

            return operationResult;
        }

        private void CreateOrLoadTags(IEnumerable<string> tags, Post newPost)
        {
            if (tags != null)
            {
                foreach (var tagName in tags)
                {
                    var tag = DataUtilities.GetOrCreateItem<Tag>(
                        x => x.TagName == tagName.ToLower(),
                        x => x.TagName = tagName.ToLower(),
                        this.dbContext);

                    newPost.Tags.Add(tag);
                }
            }
        }

    }
}
