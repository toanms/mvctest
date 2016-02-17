namespace Ca.Skoolbo.Homesite.Models.LeaderboardModels
{
    public class TabModel
    {
        public string DisplayName { get; set; }
        public string Url { get; set; }
        public double OrderBy { get; set; }

        public TabModel SetOrderBy(double index)
        {
            OrderBy = index;
            return this;
        }
    }
}
