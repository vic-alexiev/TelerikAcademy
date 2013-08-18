using StudentsDb.Models;
using StudentsDb.Repositories;
using StudentsDb.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentsDb.Services.Controllers
{
    public class SchoolsController : ApiController
    {
        private ApiControllerHelper apiControllerHelper;

        public SchoolsController()
            : this(new StudentsDbRepository())
        {
        }

        public SchoolsController(IRepository repository)
        {
            var includes = new[] { "Students" };
            apiControllerHelper = new ApiControllerHelper(repository, includes);
        }

        // GET api/<controller>
        public IEnumerable<SchoolDto> Get()
        {
            var schools = apiControllerHelper.Get<School>().AsQueryable();
            var result =
                from school in schools
                select new SchoolDto
                {
                    Id = school.Id,
                    Name = school.Name,
                    Location = school.Location
                };

            return result;
        }

        public SchoolDto Get(int id)
        {
            var school = apiControllerHelper.Get<School>(id);
            if (school == null)
            {
                throw new ArgumentException(string.Format("School with id = {0} doesn't exist.", id));
            }

            return new SchoolDto
            {
                Id = school.Id,
                Name = school.Name,
                Location = school.Location,
                Students =
                (from student in school.Students
                 select new StudentDto
                 {
                     Id = student.Id,
                     FirstName = student.FirstName,
                     LastName = student.LastName,
                     Age = student.Age,
                     Grade = student.Grade
                 }).AsEnumerable()
            };
        }

        public HttpResponseMessage Post(SchoolDto value)
        {
            var newSchool = new School
            {
                Location = value.Location,
                Name = value.Name
            };

            HttpResponseMessage response;

            try
            {
                apiControllerHelper.Post<School>(newSchool);

                var createdSchoolDto = new SchoolDto()
                {
                    Id = newSchool.Id,
                    Name = newSchool.Name,
                    Location = newSchool.Location
                };

                response = Request.CreateResponse<SchoolDto>(HttpStatusCode.Created, createdSchoolDto);
                var resourceLink = Url.Link("DefaultApi", new { id = createdSchoolDto.Id });

                response.Headers.Location = new Uri(resourceLink);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

            return response;
        }
    }
}
