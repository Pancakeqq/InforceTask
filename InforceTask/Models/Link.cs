
namespace InforceTask.Models
{
    public class Link
    {
        public Guid ID { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LongLink { get; set; }

        public string ShortLink { get; set; }
    }
}
