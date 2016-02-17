using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Ca.Skoolbo.Homesite.Models
{
    public class FeedViewModel
    {
        [DataMember(Name = "feed")]
        public List<FeedModel> Feed { get; set; }
    }
}