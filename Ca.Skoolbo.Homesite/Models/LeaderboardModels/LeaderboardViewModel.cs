using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ca.Skoolbo.Homesite.Models.LeaderboardModels
{
    public class LeaderboardViewModel
    {
        public Location Location { get; set; }
        public List<RankLeaderboardResponseModel> LeaderboardData { get; set; }
    }
}