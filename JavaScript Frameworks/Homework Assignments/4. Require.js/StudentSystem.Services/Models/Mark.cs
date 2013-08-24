using System.Runtime.Serialization;

namespace Students.Services.Models
{
    [DataContract(Name = "mark")]
    public class Mark
    {
        [DataMember(Name = "subject")]
        public string Subject { get; set; }

        [DataMember(Name = "score")]
        public float Score { get; set; }
    }
}