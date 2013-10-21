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
    public class PostsController : ApiController
    {
        [HttpGet]
        public IOrderedQueryable<PostDto> GetAll()
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

                var posts = context.Posts.Include(p => p.Tags).Include(p => p.Comments);

                var postDtos = GetAllPostDtos(posts);
                return postDtos.OrderByDescending(p => p.PostDate);
            }
            catch (Exception ex)
            {
                var errorResponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                throw new HttpResponseException(errorResponse);
            }
        }

        [HttpGet]
        public IOrderedQueryable<PostDto> GetPage(int page, int count)
        {
            var posts = this.GetAll().Skip(page * count).Take(count).OrderByDescending(p => p.PostDate);
            return posts;
        }

        [HttpGet]
        public IOrderedQueryable<PostDto> FilterByKeyword(string keyword)
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
                    .Where(p => p.Title.ToLower().IndexOf(keyword.ToLower()) >= 0);

                var postDtos = GetAllPostDtos(posts);
                return postDtos.OrderByDescending(p => p.PostDate);
            }
            catch (Exception ex)
            {
                var errorResponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                throw new HttpResponseException(errorResponse);
            }
        }

        [HttpGet]
        public IOrderedQueryable<PostDto> FilterByTags(string tags)
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

                string[] tagsSpecified = tags.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                var posts = context.Posts
                    .Include(p => p.Tags)
                    .Include(p => p.Comments)
                    .Where(p => tagsSpecified.All(s => p.Tags.Any(t => string.Compare(t.Name, s, true) == 0)));

                var postDtos = GetAllPostDtos(posts);
                return postDtos.OrderByDescending(p => p.PostDate);
            }
            catch (Exception ex)
            {
                var errorResponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                throw new HttpResponseException(errorResponse);
            }
        }

        [HttpPost]
        public HttpResponseMessage CreatePost(CreatePostDto value)
        {
            try
            {
                var sessionKey = ApiControllerHelper.GetHeaderValue(Request.Headers, "X-SessionKey");
                if (sessionKey == null)
                {
                    throw new ArgumentNullException("No session key provided in the request header!");
                }

                Validate(value.Title, "title");
                Validate(value.Text, "text");

                var context = new BloggingSystemContext();

                using (context)
                {
                    var user = context.Users.FirstOrDefault(u => u.SessionKey == sessionKey);
                    if (user == null)
                    {
                        throw new ArgumentException("Users must be logged in to create posts!");
                    }

                    var newPost = new Post()
                    {
                        Title = value.Title,
                        Text = value.Text,
                        PostDate = DateTime.Now,
                        Author = user
                    };

                    string[] tagsFromTitle = value.Title.Split(
                        new char[] { ' ', ',', '.', ';', '!', '?', ':' },
                        StringSplitOptions.RemoveEmptyEntries);

                    List<string> tagsToCheck = new List<string>();

                    foreach (var tagFromTitle in tagsFromTitle)
                    {
                        tagsToCheck.Add(tagFromTitle);
                    }

                    if (value.Tags != null)
                    {
                        foreach (string tagName in value.Tags)
                        {
                            tagsToCheck.Add(tagName);
                        }
                    }

                    foreach (string tagName in tagsToCheck)
                    {
                        var matchingTag = context.Tags.FirstOrDefault(t => string.Compare(t.Name, tagName, true) == 0);
                        if (matchingTag == null)
                        {
                            // tag not found, insert it in the database
                            matchingTag = new Tag
                            {
                                Name = tagName.ToLower()
                            };

                            context.Tags.Add(matchingTag);
                            context.SaveChanges();
                        }

                        newPost.Tags.Add(matchingTag);
                    }

                    context.Posts.Add(newPost);
                    context.SaveChanges();

                    var createdPostDto = new CreatePostDto()
                    {
                        Id = newPost.Id,
                        Title = newPost.Title,
                        Tags = newPost.Tags.Select(t => t.Name),
                        Text = newPost.Text
                    };

                    var response = Request.CreateResponse(HttpStatusCode.Created, createdPostDto);
                    return response;
                }
            }
            catch (Exception ex)
            {
                var errorResponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                throw new HttpResponseException(errorResponse);
            }
        }

        [HttpPost]
        [ActionName("comment")]
        public HttpResponseMessage CreateComment(int postId, [FromBody] CommentDto value)
        {
            try
            {
                var sessionKey = ApiControllerHelper.GetHeaderValue(Request.Headers, "X-SessionKey");
                if (sessionKey == null)
                {
                    throw new ArgumentNullException("No session key provided in the request header!");
                }

                Validate(value.Text, "text");

                var context = new BloggingSystemContext();

                using (context)
                {
                    var user = context.Users.FirstOrDefault(u => u.SessionKey == sessionKey);
                    if (user == null)
                    {
                        throw new ArgumentException("Users must be logged in to leave comments!");
                    }

                    var post = context.Posts.FirstOrDefault(p => p.Id == postId);
                    if (post == null)
                    {
                        throw new ArgumentException("Invalid post id: " + postId);
                    }

                    var newComment = new Comment()
                    {
                        Text = value.Text,
                        PostDate = DateTime.Now,
                        Author = user,
                        Post = post
                    };

                    context.Comments.Add(newComment);
                    context.SaveChanges();

                    var response = Request.CreateResponse(HttpStatusCode.OK);
                    return response;
                }
            }
            catch (Exception ex)
            {
                var errorResponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                throw new HttpResponseException(errorResponse);
            }
        }

        #region Private Fields

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

        private void Validate(string value, string paramName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(paramName, "Value cannot be null or empty.");
            }
        }

        #endregion
    }
}
