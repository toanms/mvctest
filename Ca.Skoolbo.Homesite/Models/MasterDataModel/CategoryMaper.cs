using CsvHelper.Configuration;

namespace Ca.Skoolbo.Homesite.Models.MasterDataModel
{
    public sealed class CategoryMaper : CsvClassMap<Category>
    {
        public CategoryMaper()
        {
            Map(m => m.CategoryCode).Name("Category Code");
            Map(m => m.CategoryName).Name("Category Title");
            Map(m => m.CourseId).Name("Course");
            Map(m => m.Icon).Name("Icon");
            Map(m => m.Rating).Name("Rating");
            Map(m => m.LowScore).Name("Low Score");
            Map(m => m.HighScore).Name("High Score");
        }
    }
}