using BloggingSystem.Data;
using BloggingSystem.Models;
using BloggingSystem.Services.Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace BloggingSystem.Services.Controllers
{
    public class UsersController : ApiController
    {
        private const int MinUsernameLength = 6;
        private const int MaxUsernameLength = 30;
        private const int MinDisplayNameLength = 6;
        private const int MaxDisplayNameLength = 30;
        private const string ValidUsernameCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890._";
        private const string ValidDisplayNameCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890._ -";
        private const string SessionKeyCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private const int SessionKeyLength = 50;
        private const int Sha1HashLength = 40;

        private static readonly Random randomNumberGenerator = new Random();

        [HttpPost]
        [ActionName("register")]
        public HttpResponseMessage RegisterUser(UserDto value)
        {
            BloggingSystemContext context = null;

            try
            {
                context = new BloggingSystemContext();

                this.ValidateUserIdentifier(
                    value.Username,
                    "Username",
                    MinUsernameLength,
                    MaxUsernameLength,
                    ValidUsernameCharacters);

                this.ValidateUserIdentifier(
                    value.DisplayName,
                    "Display name",
                    MinDisplayNameLength,
                    MaxDisplayNameLength,
                    ValidDisplayNameCharacters);

                this.ValidateAuthCode(value.AuthCode);

                var user = context.Users.FirstOrDefault(
                    u => u.Username == value.Username ||
                        u.DisplayName == value.DisplayName);

                if (user != null)
                {
                    throw new InvalidOperationException("User already exists.");
                }

                user = new User()
                {
                    Username = value.Username,
                    DisplayName = value.DisplayName,
                    AuthCode = value.AuthCode
                };

                context.Users.Add(user);
                context.SaveChanges();

                user.SessionKey = this.GenerateSessionKey(user.Id);
                context.SaveChanges();

                var loggedUserDto = new LoggedUserDto()
                {
                    DisplayName = user.DisplayName,
                    SessionKey = user.SessionKey
                };

                var response = Request.CreateResponse(HttpStatusCode.Created, loggedUserDto);
                return response;
            }
            catch (Exception ex)
            {
                var errorResponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                throw new HttpResponseException(errorResponse);
            }
            finally
            {
                if (context != null)
                {
                    context.Dispose();
                }
            }
        }

        [HttpPost]
        [ActionName("login")]
        public HttpResponseMessage LoginUser(UserDto value)
        {
            BloggingSystemContext context = null;

            try
            {
                context = new BloggingSystemContext();

                this.ValidateUserIdentifier(
                    value.Username,
                    "Username",
                    MinUsernameLength,
                    MaxUsernameLength,
                    ValidUsernameCharacters);
                this.ValidateAuthCode(value.AuthCode);

                var user = context.Users.FirstOrDefault(
                    u => u.Username == value.Username &&
                        u.AuthCode == value.AuthCode);

                if (user == null)
                {
                    throw new InvalidOperationException("Invalid username or password.");
                }

                if (user.SessionKey == null || user.SessionKey.Length != SessionKeyLength)
                {
                    user.SessionKey = this.GenerateSessionKey(user.Id);
                    context.SaveChanges();
                }

                var loggedUserDto = new LoggedUserDto()
                {
                    DisplayName = user.DisplayName,
                    SessionKey = user.SessionKey
                };

                var response = Request.CreateResponse(HttpStatusCode.Accepted, loggedUserDto);
                return response;
            }
            catch (Exception ex)
            {
                var errorResponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                throw new HttpResponseException(errorResponse);
            }
            finally
            {
                if (context != null)
                {
                    context.Dispose();
                }
            }
        }

        [HttpPut]
        [ActionName("logout")]
        public HttpResponseMessage LogoutUser()
        {
            BloggingSystemContext context = null;

            try
            {
                string sessionKey = ApiControllerHelper.GetHeaderValue(Request.Headers, "X-SessionKey");
                if (sessionKey == null)
                {
                    throw new ArgumentNullException("No session key provided in the request header!");
                }

                context = new BloggingSystemContext();

                var user = context.Users.FirstOrDefault(u => u.SessionKey == sessionKey);

                if (user.SessionKey == null)
                {
                    throw new ArgumentNullException("User is already logged out!");
                }

                user.SessionKey = null;
                context.SaveChanges();

                var response = Request.CreateResponse(HttpStatusCode.OK);
                return response;
            }
            catch (Exception ex)
            {
                var errorResponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                throw new HttpResponseException(errorResponse);
            }
            finally
            {
                if (context != null)
                {
                    context.Dispose();
                }
            }
        }

        #region Private Methods

        private string GenerateSessionKey(int id)
        {
            StringBuilder sessionKeyBuilder = new StringBuilder(SessionKeyLength);
            sessionKeyBuilder.Append(id);

            while (sessionKeyBuilder.Length < SessionKeyLength)
            {
                var index = randomNumberGenerator.Next(SessionKeyCharacters.Length);
                sessionKeyBuilder.Append(SessionKeyCharacters[index]);
            }

            return sessionKeyBuilder.ToString();
        }

        private void ValidateAuthCode(string authCode)
        {
            if (authCode == null || authCode.Length != Sha1HashLength)
            {
                throw new ArgumentOutOfRangeException("Password should be encrypted.");
            }
        }

        private void ValidateUserIdentifier(string name, string nameType, int minLength, int maxLength, string validCharacters)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name", string.Format("{0} cannot be null.", nameType));
            }
            else if (name.Length < minLength)
            {
                throw new ArgumentOutOfRangeException(
                    "name",
                    string.Format(
                    "{0} must be at least {1} characters long.",
                    nameType,
                    MinUsernameLength));
            }
            else if (name.Length > maxLength)
            {
                throw new ArgumentOutOfRangeException(
                    "name",
                    string.Format(
                    "{0} must be less than {1} characters long.",
                    nameType,
                    maxLength));
            }
            else if (name.Any(ch => !validCharacters.Contains(ch)))
            {
                throw new ArgumentOutOfRangeException(
                    "name",
                    string.Format(
                    "{0} must contain only the following characters: {1}",
                    nameType,
                    validCharacters));
            }
        }

        #endregion
    }
}
