using System.Collections.Generic;
using Ca.Skoolbo.Homesite.Models.LeaderboardModels;

namespace Ca.Skoolbo.Homesite.ViewModels
{
    public class LeaderboardMainViewModel
    {
        public Location Location { get; set; }

        public List<TabModel> Tabs { get; set; }

        public EventTimeModel EventTime { get; set; }
    }
}
