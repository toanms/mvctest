namespace Ca.Skoolbo.Homesite.Models.ModelConverts
{
    public class AnalysisConvert
    {
        //public static IEnumerable<AnalysisPersonalBestModel> AnalysisPersonalBest(List<PersonalBestModel> personalBestModels)
        //{
        //    if (personalBestModels != null && personalBestModels.Any())
        //    {
        //        foreach (var item in personalBestModels)
        //        {

        //            if (item != null)
        //            {
        //                string avatar = string.Empty;
        //                string schoolName = string.Empty;
        //                string schoolState = string.Empty;
        //                string categoryName = string.Empty;
        //                string displayName = string.Empty;

        //                if (item.User != null)
        //                {
        //                    avatar = ModelBase.DnaImageUrl(item.User.Dna);
        //                    displayName = item.User.Firstname + " " + item.User.Lastname;

        //                    if (Database.Schools != null)
        //                    {
        //                        var schoolCode = item.User.SchoolCode;

        //                        var isExistSchool = Database.Schools.IsExists(schoolCode);
        //                        if (isExistSchool)
        //                        {
        //                            var school = Database.Schools[schoolCode];
        //                            schoolName = school.SchoolName;
        //                            schoolState = school.SchoolState;
        //                        }
        //                    }
        //                    var data = item.Data;
        //                    if (data != null)
        //                    {

        //                        var courseCode = data.Course;
        //                        var categoryCode = data.CategoryCode;

        //                        categoryName = CategoryStore.GetProperyCategoryByKey(categoryCode + courseCode, c => c.CategoryName);

        //                    }
        //                }

        //                yield return new AnalysisPersonalBestModel
        //                {
        //                    Time = item.Created.Humanize(),
        //                    Avatar = avatar,
        //                    SchoolName = schoolName,
        //                    State = schoolState,
        //                    CategoryName = categoryName,
        //                    DisplayName = displayName
        //                };
        //            }
        //        }
        //    }
        //}


       
    }
}