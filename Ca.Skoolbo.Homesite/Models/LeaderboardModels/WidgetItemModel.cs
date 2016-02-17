namespace Ca.Skoolbo.Homesite.Models.LeaderboardModels
{
    public class WidgetItemModel
    {
        public WidgetItemModel()
        {
            
        }

        public WidgetItemModel(double value, string displayName, string url = "")
        {
            Value = value;
            DisplayName = displayName;
            Url = url;
        }

        public double Value { get; set; }

        public string ValueDisplay
        {
            get
            {
                if(Value > 0)
                    return string.Format("{0:##,###}{1}", Value, SubFix);
                return "0";
            }
        }

        public string SubFix { get; set; }

        public string DisplayName { get; set; }

        public string Url { get; set; }

        public string Image { get; set; }

        public int Order { get; set; }

        public WidgetItemModel SetOrderBy(int orderBy)
        {
            Order = orderBy;
            return this;
        }
    }
}
