using System;

namespace Skoolbo.ApiClient.Models.AnalysisLeaderboardModels
{
    public class TotalAnswerSummaryModel
    {
        public double Start { get; set; }
        public double Duration { get; set; }

        public float StartScore { get; set; }
        public float EndScore { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
    }
}
