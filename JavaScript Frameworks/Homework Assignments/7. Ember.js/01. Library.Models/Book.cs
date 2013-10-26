using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    [DataContract(Name = "book")]
    public class Book
    {
        [Key]
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [StringLength(200)]
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [StringLength(100)]
        [DataMember(Name = "author")]
        public string Author { get; set; }

        [StringLength(50)]
        [DataMember(Name = "isbn")]
        public string Isbn { get; set; }

        [StringLength(200)]
        [DataMember(Name = "webSite")]
        public string WebSite { get; set; }

        [StringLength(3000)]
        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "publicationDate")]
        public DateTime PublicationDate { get; set; }

        [StringLength(100)]
        [DataMember(Name = "category")]
        public string Category { get; set; }
    }
}
