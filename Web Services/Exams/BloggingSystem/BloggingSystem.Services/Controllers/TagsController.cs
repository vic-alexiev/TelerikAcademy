using BloggingSystem.Data;
using BloggingSystem.Models;
using BloggingSystem.Services.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BloggingSystem.Services.Controllers
{
    public class TagsController : ApiController
    {
        [HttpGet]
        public IOrderedQueryable<TagDto> GetAll()
        {
            try
            {
                var sessionKey = ApiControllerHelper.GetHeaderValue(Request.Headers, "X-SessionKey");
                if (sessionKey == null)
                {
                    throw new ArgumentNullException("No session key provided in the request header!");
                }

                var context = new BloggingSystemContext();

                var user = context.Users.FirstOrDefault(u => u.SessionKey == sessionKey);

                if (user == null)
                {
                    throw new InvalidOperationException("Invalid username or password.");
                }

                var tags = context.Tags.Include(t => t.Posts).AsQueryable();

                var tagDtos = GetAllTagDtos(tags);
                return tagDtos.OrderBy(t => t.Name);
            }
            catch (Exception ex)
            {
                var errorResponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                throw new HttpResponseException(errorResponse);
            }
        }

        [HttpGet]
        [ActionName("posts")]
        public IOrderedQueryable<PostDto> GetPostsForTag(int tagId)
        {
            try
            {
                var sessionKey = ApiControllerHelper.GetHeaderValue(Request.Headers, "X-SessionKey");
                if (sessionKey == null)
                {
                    throw new ArgumentNullException("No session key provided in the request header!");
                }

                var context = new BloggingSystemContext();

                var user = context.Users.FirstOrDefault(u => u.SessionKey == sessionKey);

                if (user == null)
                {
                    throw new InvalidOperationException("Invalid username or password.");
                }

                var posts = context.Posts
                    .Include(p => p.Tags)
                    .Include(p => p.Comments)
                    .Where(p => p.Tags.Any(t => t.Id == tagId))
                    .AsQueryable();

                var postDtos = GetAllPostDtos(posts);
                return postDtos.OrderByDescending(t => t.PostDate);
            }
            catch (Exception ex)
            {
                var errorResponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                throw new HttpResponseException(errorResponse);
            }
        }

        #region Private Methods

        private IQueryable<TagDto> GetAllTagDtos(IQueryable<Tag> tags)
        {
            var tagDtos =
                from tag in tags
                select new TagDto()
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    PostsCount = tag.Posts.Count
                };

            return tagDtos.AsQueryable();
        }

        private IQueryable<PostDto> GetAllPostDtos(IQueryable<Post> posts)
        {
            var postDtos =
                from post in posts
                select new PostDto()
                {
                    Id = post.Id,
                    Title = post.Title,
                    Author = post.Author.DisplayName,
                    PostDate = post.PostDate,
                    Text = post.Text,
                    Tags = post.Tags.Select(t => t.Name).OrderBy(n => n),
                    Comments =
                    (from comment in post.Comments
                     select new CommentDto
                     {
                         Text = comment.Text,
                         Author = comment.Author.DisplayName,
                         PostDate = comment.PostDate
                     })
                };

            return postDtos.AsQueryable();
        }

        #endregion
    }
}
