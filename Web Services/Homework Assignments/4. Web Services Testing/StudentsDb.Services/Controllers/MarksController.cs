using StudentsDb.Models;
using StudentsDb.Services.Models;
using System.Web.Http;

namespace StudentsDb.Services.Controllers
{
    public class MarksController : ApiController
    {
        public MarksController()
        {
            var includes = new[] { "Student" };
        }
    }
}
