using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Ca.Skoolbo.Homesite.Helpers;
using Ca.Skoolbo.Homesite.Helpers.Configs;
using Ca.Skoolbo.Homesite.Models.LeaderboardModels;
using Ca.Skoolbo.Homesite.Resources;
using Ca.Skoolbo.Homesite.ViewModels;
using Skoolbo.ApiClient.AnalysisLeaderboardClients;
using Skoolbo.ApiClient.Models.AnalysisLeaderboardModels;

namespace Ca.Skoolbo.Homesite.Controllers
{
    public class LeaderboardController : Controller
    {
        private readonly IAnalysisLeaderboardClient _analysisLeaderboardClient;
        private const string TimerFilter = "weekly";

        public LeaderboardController(IAnalysisLeaderboardClient analysisLeaderboardClient)
        {
            _analysisLeaderboardClient = analysisLeaderboardClient;
        }

        // GET: Leaderboard
        public ActionResult Widget(Location location = Location.Global)
        {
            var widgetModel = new WidgetModel
            {
                Location = location
            };

            var dataDailyAnalysis = _analysisLeaderboardClient.GetDailyAnalysis(location.GetCustomAttributeDescription());
            if (dataDailyAnalysis != null)
            {
                var widgetItems = ConvertFromDailyAnalysisToWidget(dataDailyAnalysis, location);
                if (widgetItems != null)
                {
                    widgetModel.Widgets = widgetItems.OrderBy(c => c.Order).ToList();
                }
            }

            return View("_Widget", widgetModel);
        }

        public async Task<ActionResult> Totalizer(Location location = Location.Global, int startfix = 0)
        {
            var leaderboardTotalAnswerModel = new TotalAnswerReponseModel();
            if (!Request.IsAjaxRequest())
            {
                return Json(leaderboardTotalAnswerModel, JsonRequestBehavior.AllowGet);
            }

            float endScore = 0;
            float startScore = 0;

            DateTime startTime = DateTime.UtcNow;
            DateTime endTime = DateTime.UtcNow;

            var totalAnswerFromGlobal = await _analysisLeaderboardClient.GetLeaderboardTotalizerFromGlobalServiceAsync(location == Location.Global);
            if (totalAnswerFromGlobal != null)
            {
                endScore = totalAnswerFromGlobal.EndScore;
                startScore = startfix > 0 ? startfix : totalAnswerFromGlobal.StartScore;

                startTime = totalAnswerFromGlobal.StartTime.UtcDateTime;
                endTime = totalAnswerFromGlobal.EndTime.UtcDateTime;
            }
            else
            {
                var totalizerResult = _analysisLeaderboardClient.GetLeaderboardTotalizer(location == Location.Global, WebConfigHelper.MasterToken);
                if (totalizerResult != null && totalizerResult.Result.IsNotNullOrEmpty())
                {
                    int bonusScore = 0;
                    if (location == Location.Global)
                    {
                        bonusScore = 80065595;
                        int Ph = 118700;

                        int Mx = 2903586;

                        bonusScore = bonusScore + Mx + Ph;
                    }
                    else
                    {
                        bonusScore = 268249;
                    }

                    var totalAnswserList = totalizerResult.Result;

                    var leftScore = totalAnswserList.Count == 1 ? totalAnswserList : totalAnswserList.Where(w => totalAnswserList.IndexOf(w) % 2 != 0).ToList();
                    var rightScore = totalAnswserList.Count == 1 ? totalAnswserList : totalAnswserList.Where(w => totalAnswserList.IndexOf(w) % 2 == 0).ToList();

                    startScore = (startfix > 0 ? startfix : leftScore.Sum(s => s.Score));

                    startScore = startScore + bonusScore;

                    endScore = rightScore.Sum(s => s.Score);

                    endScore = endScore + bonusScore;

                    startTime = leftScore.Min(c => c.TimeStamp);

                    endTime = rightScore.Max(c => c.TimeStamp);
                }

            }

            var currentTime = DateTime.UtcNow;

            leaderboardTotalAnswerModel.End = endScore;

            var operationTime = currentTime.Subtract(endTime).TotalSeconds / endTime.Subtract(startTime).TotalSeconds;

            double start = (startScore + operationTime * (endScore - startScore));

            leaderboardTotalAnswerModel.Start = (start < endScore ? Math.Round(start) : endScore);

            var timespan = new TimeSpan(endTime.Ticks * 2 - startTime.Ticks - currentTime.Ticks);

            var duration = timespan.TotalSeconds;

            leaderboardTotalAnswerModel.Duration = duration;

            leaderboardTotalAnswerModel.StartTime = startTime;
            leaderboardTotalAnswerModel.EndTime = endTime;

            leaderboardTotalAnswerModel.StartScore = startScore;
            leaderboardTotalAnswerModel.EndScore = endScore;
            leaderboardTotalAnswerModel.TotalStartTime = start;
            leaderboardTotalAnswerModel.TotalEndTime = duration;


            return Json(leaderboardTotalAnswerModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LeaderboardMain(Location location = Location.Country)
        {

            var viewModel = new LeaderboardMainViewModel
            {
                Location = location,
                Tabs = ResourceTabs(location),
                Locations = ResourceTabsLocation(location)
            };

            var currentDate = DateTime.Now;

            viewModel.EventTime = new EventTimeModel
            {
                BeginTime = currentDate,
                EndTime = currentDate.EndOfWeek(DayOfWeek.Monday)
            };
            return PartialView("_LeaderboardMain", viewModel);
        }

        public ActionResult LeaderboardForPersonalBest(Location location = Location.Country)
        {
            var leaderboardDataOutPut = _analysisLeaderboardClient.GetPersonalBest(50);

            var leaderboardData = LeaderboardHelper.ProcessDataPersonalBests(leaderboardDataOutPut);

            return PartialView("_LeaderboardForPersonalBest", leaderboardData);
        }

        public ActionResult LeaderboardForCountry(Location location = Location.Country)
        {
            var leaderboardDataOutPut = _analysisLeaderboardClient.GetLeaderboardStudents(TimerFilter, location == Location.Global, WebConfigHelper.MasterToken);

            var leaderboardData = LeaderboardHelper.LeaderboardModelToRankLeaderBoard(leaderboardDataOutPut);

            var viewModel = new LeaderboardViewModel()
            {
                LeaderboardData = leaderboardData,
                Location = location
            };

            return PartialView("_LeaderboardForCountry", viewModel);
        }

        public ActionResult LeaderBoardForClasses(Location location = Location.Country)
        {
            var leaderboardDataOutPut = _analysisLeaderboardClient.GetLeaderboardClasses(string.Empty, location == Location.Global, WebConfigHelper.MasterToken);

            var leaderboardData = LeaderboardHelper.LeaderboardModelToRankLeaderBoard(leaderboardDataOutPut);

            var viewModel = new LeaderboardViewModel()
            {
                LeaderboardData = leaderboardData,
                Location = location
            };

            return PartialView("_LeaderBoardForClasses", viewModel);
        }

        public ActionResult LeaderBoardForSchools(Location location = Location.Country)
        {
            var leaderboardDataOutPut = _analysisLeaderboardClient.GetLeaderboardSchools(string.Empty, location == Location.Global, WebConfigHelper.MasterToken);

            var leaderboardData = LeaderboardHelper.LeaderboardModelToRankLeaderBoard(leaderboardDataOutPut);

            var viewModel = new LeaderboardViewModel()
            {
                LeaderboardData = leaderboardData,
                Location = location
            };
            return PartialView("_LeaderBoardForSchools", viewModel);
        }

        #region Private Method

        private List<WidgetItemModel> ConvertFromDailyAnalysisToWidget(DailyAnalysisModel model, Location location)
        {
            if (model == null)
                return null;

            var avgImprovement = new WidgetItemModel(model.AverageImpovement,
                location == Location.Country
                    ? ResourceDisplay.GlobalAvgImprovement
                    : ResourceDisplay.CountryAvgImprovement)
            {
                Image = Url.Content("~/Images/Leaderboad/avg_improvement.png")
            };
            avgImprovement.SubFix = "%";

            var millionClub = new WidgetItemModel(model.SchoolAnswers1000000,
                location == Location.Country ? ResourceDisplay.GlobalMillionClub : ResourceDisplay.CountryMillionClub,
                location == Location.Country ? WebConfigHelper.DashboardLink + "superschools" : string.Empty)
            {
                Image = Url.Content("~/Images/Leaderboad/1M.png")
            };

            var personBest = new WidgetItemModel(model.PersonalBest,
                location == Location.Country ? ResourceDisplay.GlobalPersonalBest : ResourceDisplay.CountryPersonalBest,
                location == Location.Country ? WebConfigHelper.DashboardLink + "personalbest" : string.Empty)
            {
                Image = Url.Content("~/Images/Leaderboad/personalBest.png"),
                Url = WebConfigHelper.DashboardLink + "personalBest"
            };

            var school = new WidgetItemModel(model.SchoolRegistered,
                location == Location.Country ? ResourceDisplay.GlobalSchool : ResourceDisplay.CountrySchool)
            {
                Image = Url.Content("~/Images/Leaderboad/schools.png")
            };

            if (location == Location.Global)
            {
                school.Value += 857 + 94 + 37;
            }

            var supperChamps = new WidgetItemModel(model.CurrentSuperChampCount,
                location == Location.Country ? ResourceDisplay.GlobalSuperChamps : ResourceDisplay.CountrySuperChamps)
            {
                Image = Url.Content("~/Images/Leaderboad/supperChamps.png")
            };

            return new List<WidgetItemModel>
                        {
                            school.SetOrderBy(5),
                            supperChamps.SetOrderBy(10),
                            millionClub.SetOrderBy(15),
                            personBest.SetOrderBy(20),
                            avgImprovement.SetOrderBy(25)
                        };
        }


        public List<TabModel> ResourceTabs(Location location = Location.Global)
        {
            var tabs = new List<TabModel>();

            var tabPersonalBest = new TabModel
            {
                Url = Url.Action("LeaderboardForPersonalBest", "Leaderboard", new { }),
                DisplayName = location == Location.Global ? ResourceDisplay.GlobalPersonalBestTab : ResourceDisplay.CountryPersonalBestTab,
                OrderBy = 0
            };

            var tabStudents = new TabModel
            {
                Url = Url.Action("LeaderboardForCountry", "Leaderboard", new { }),
                DisplayName = location == Location.Global ? ResourceDisplay.GlobalStudentsTab : ResourceDisplay.CountryStudentsTab,
                OrderBy = 1
            };

            var tabClasses = new TabModel
            {
                Url = Url.Action("LeaderBoardForClasses", "Leaderboard", new { }),
                DisplayName = location == Location.Global ? ResourceDisplay.GlobalClassesTab : ResourceDisplay.CountryClassesTab,
                OrderBy = 5
            };

            var tabSchools = new TabModel
            {
                Url = Url.Action("LeaderBoardForSchools", "Leaderboard", new { }),
                DisplayName = location == Location.Global ? ResourceDisplay.GlobalSchoolsTab : ResourceDisplay.CountrySchoolsTab,
                OrderBy = 10
            };

            tabs.Add(tabPersonalBest);
            tabs.Add(tabStudents);
            tabs.Add(tabClasses);
            tabs.Add(tabSchools);

            return tabs;
        }

        public List<TabLocationModel> ResourceTabsLocation(Location location)
        {
            var tabs = new List<TabLocationModel>();

            tabs.Add(new TabLocationModel()
            {
                Location = Location.Country,
                DisplayName = location == Location.Global ? ResourceDisplay.GlobalCaTab : ResourceDisplay.CountryCaTab,
                OrderBy = 1
            });

            tabs.Add(new TabLocationModel()
            {
                Location = Location.Global,
                DisplayName = location == Location.Global ? ResourceDisplay.GlobalWorldTab : ResourceDisplay.CountryWorldTab,
                OrderBy = 1
            });

            return tabs;
        }

        #endregion


    }
}