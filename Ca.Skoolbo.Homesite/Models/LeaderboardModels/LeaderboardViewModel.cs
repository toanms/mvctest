using System.Collections.Generic;

namespace Ca.Skoolbo.Homesite.Models.LeaderboardModels
{
    public class LeaderboardViewModel
    {
        public Location Location { get; set; }
        public List<RankLeaderboardResponseModel> LeaderboardData { get; set; }
    }
}