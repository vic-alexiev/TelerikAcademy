using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BloggingSystem.Services.Models
{
    [DataContract(Name = "post")]
    public class CreatePostDto
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "tags")]
        public IEnumerable<string> Tags { get; set; }

        [DataMember(Name = "text")]
        public string Text { get; set; }
    }
}