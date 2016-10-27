using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Ca.Skoolbo.Homesite.Extensions;
using Ca.Skoolbo.Homesite.Helpers.Configs;
using Ca.Skoolbo.Homesite.Models;
using Ca.Skoolbo.Homesite.Models.MasterDataModel;

namespace Ca.Skoolbo.Homesite.Helpers
{
    public class CategoryStore
    {
        private static Dictionary<string, Category> _categories;
        private static Dictionary<string, List<Category>> _categoriesByCourse;

        public static Dictionary<string, Category> CategoryList()
        {

            if (_categories != null)
                return _categories;

            _categories = new Dictionary<string, Category>();

            var categoryPath = HttpContext.Current.Server.MapPath("~/App_Data/" + WebConfigHelper.Region + "/category.csv");

            var task = Task.Run(() => ReadCategoryByFile(categoryPath));

            task.Wait();

            _categories = task.Result;

            var fileInFolder = HttpContext.Current.Server.MapPath("~/App_Data/" + WebConfigHelper.Region + "/category-language");

            var directoryInfo = new DirectoryInfo(fileInFolder);

            var files = directoryInfo.GetFiles();

            var taskReadFile = new List<Task<Dictionary<string, Category>>>();

            foreach (var fileInfo in files)
            {
                var info = fileInfo;

                var taskCurrent = Task.Run(() =>
                {
                    var score = info.Name.Replace("category_", "").Replace(".csv", "");

                    return ReadCategoryByFile(info.FullName, score);
                });

                taskReadFile.Add(taskCurrent);

            }

            var whenAll = Task.WhenAll(taskReadFile);

            whenAll.Wait();

            var dataStore = whenAll.Result;

            if (dataStore != null)
            {
                foreach (var dictionary in dataStore)
                {
                    _categories = _categories.Concat(dictionary).ToDictionary(c => c.Key, c => c.Value);
                }
            }
            return _categories.Where(w => w.Value != null && !w.Value.CategoryName.Contains("Test")).ToDictionary(w => w.Key, w => w.Value);
        }

        public static Dictionary<string, List<Category>> CategoriesByCourse()
        {
            if (_categoriesByCourse == null)
            {
                _categoriesByCourse = new Dictionary<string, List<Category>>();

                _categoriesByCourse = CategoryList().GroupBy(c => c.Value.CourseId).Select(s => new
                {
                    CourseId = s.Key,
                    Catetogry = s.Select(c => c.Value).ToList()
                }).ToDictionary(c => c.CourseId, c => c.Catetogry);

                return _categoriesByCourse;
            }
            return _categoriesByCourse;
        }

        private static Dictionary<string, Category> ReadCategoryByFile(string fileName, string course = "")
        {
            var categoryStore = new Dictionary<string, Category>();
            CsvHelperExtension.ReadCsvFromPath(fileName, csvReader =>
            {
                while (csvReader.Read())
                {
                    var currentCourse = course;

                    Category category = csvReader.GetRecord<Category>();

                    if (category != null)
                    {
                        if (string.IsNullOrEmpty(currentCourse))
                            currentCourse = category.CourseId;

                        var key = category.CategoryCode + currentCourse;

                        category.CourseId = currentCourse;

                        categoryStore.Add(key, category);
                    }
                }

            }, reader =>
            {
                CsvHelperExtension.CsvReaderConfig(reader, Encoding.ASCII);
                reader.Configuration.Delimiter = ";";
                reader.Configuration.RegisterClassMap(typeof(CategoryMaper));
            });

            return categoryStore;
        }
    }
}