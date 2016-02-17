using System;

namespace Ca.Skoolbo.Homesite.Models.LeaderboardModels
{
    public class TotalAnswerReponseModel
    {
        public double Start { get; set; }
        public double End { get; set; }
        public double Duration { get; set; }
        public double TotalEndTime { get; set; }
        public double TotalStartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime StartTime { get; set; }
        public double StartScore { get; set; }
        public double EndScore { get; set; }
    }
}