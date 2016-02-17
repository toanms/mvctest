using System;
using System.Runtime.Serialization;

namespace Ca.Skoolbo.Homesite.Models
{
    public class FeedModel
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }
        [DataMember(Name = "link")]
        public string Link { get; set; }
        [DataMember(Name = "date")]
        public DateTime? Date { get; set; }
        [DataMember(Name = "summary")]
        public string Summary { get; set; }
        [DataMember(Name = "image")]
        public string Image { get; set; }
    }
}