using System.ComponentModel.DataAnnotations;

namespace InforceTask.Models
{
    public class AddLinkModel
    {
        [Required]
        [DataType(DataType.Url)]
        public string LongLink { get; set; }
        public string ShortLink { get; set; }

        public List<Link> Links { get; set; }

        public string ErrorMessage { get; set; }
    }
}
