using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineDatingSystem.Models
{
    public class UserDto
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime BirthDate { get; set; }

        public int CountryId { get; set; }

        public int CityId { get; set; }

        public string Sex { get; set; }

        public string LookingFor { get; set; }

        public int EducationTypeId { get; set; }

        public string Description { get; set; }

        public byte[] Photo { get; set; }

        public List<int> InterestIds { get; set; }

        public int ReasonId { get; set; }
    }
}