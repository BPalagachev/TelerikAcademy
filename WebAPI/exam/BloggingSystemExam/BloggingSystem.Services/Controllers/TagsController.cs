using BloggingSystem.DataLayer;
using BloggingSystem.Services.Attributes;
using BloggingSystem.Services.DataTransferObjects;
using System;
using System.Linq;
using System.Web.Http.ValueProviders;

namespace BloggingSystem.Services.Controllers
{
    public class TagsController : BaseApiController
    {
        private BloggingSystemContext dbContext = new BloggingSystemContext();

        public IQueryable<TagDto> GetAll([ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var operationResult = this.PerformOperationAndHandleExceptions(() =>
            {
                bool isAuthorized = this.dbContext.Users.Any(x => x.SessionKey == sessionKey);
                if (!isAuthorized)
                {
                    throw new InvalidOperationException("Not authorized to view this page");
                }

                var tags = this.dbContext.Tags
                    .OrderBy(x => x.TagName)
                    .Select(TagDto.FromTag);
                return tags;
            });

            return operationResult;
        }

        public IQueryable<PostDto> GetPosts(int tagId,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var operationResult = this.PerformOperationAndHandleExceptions(() =>
            {
                bool isAuthorized = this.dbContext.Users.Any(x => x.SessionKey == sessionKey);
                if (!isAuthorized)
                {
                    throw new InvalidOperationException("Not authorized to view this page.");
                }

                bool doesTagExists = this.dbContext.Tags.Any(x => x.Id == tagId);
                if (!doesTagExists)
                {
                    throw new InvalidOperationException("Tag with this id does not exist.");

                }

                var posts = this.dbContext.Posts
                    .OrderByDescending(x => x.PostDate)
                    .Where(x => x.Tags.Any(tag => tag.Id == tagId))
                    .Select(PostDto.FromPost);

                return posts;
            });

            return operationResult;
        }
    }
}
