using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Ca.Skoolbo.Homesite.Helpers.Configs;
using Ca.Skoolbo.Homesite.Models;
using Ca.Skoolbo.Homesite.Models.LeaderboardModels;
using Ca.Skoolbo.Homesite.Resources;
using Humanizer;
using Skoolbo.ApiClient.Models.AnalysisLeaderboardModels;

namespace Ca.Skoolbo.Homesite.Helpers
{
    public static class LeaderboardHelper
    {
        private static readonly Dictionary<string, Category> Categories  = CategoryStore.CategoryList();
        public static List<LeaderboardPersonalBestModel> ProcessDataPersonalBests(List<PersonalBestModel> personalBests)
        {
            var res = personalBests.Select(c =>
             {
                 var item = new LeaderboardPersonalBestModel
                 {
                     State = c.User.State,
                     Displayname = $"{c.User.Firstname} {c.User.Lastname}".Trim(),
                     Avatar = ModelBase.DnaImageUrl(c.User.Dna),
                     SchoolName = c.User.SchoolCode == "SIN" ? "Skoolbo International" : c.User.SchoolName,
                     Time = c.Created.Humanize(),
                     StateLogo = string.Format(Assets.State, WebConfigHelper.FolderImageS3.ToUpper().ToUpper(), string.IsNullOrEmpty(c.User.State) ? "SIN" : c.User.State.Trim().ToUpper())
                 };

                 var key = $"{c.Data.CategoryCode}{c.Data.Course}";
                 if (Categories.ContainsKey(key))
                 {
                     item.CategoryName = Categories[key].CategoryName;
                 }

                 return item;
             }).ToList();

            return res;
        }

        public static List<RankLeaderboardResponseModel> LeaderboardModelToRankLeaderBoard(LeaderBoardModel leaderBoardResult)
        {
            if (leaderBoardResult.Ranks == null) return null;

            var data = leaderBoardResult;

            return data.Ranks.GroupBy(c => c.PlayerId)
                .SelectMany(sm => sm)
                .Select(c =>
                {
                    var item = new RankLeaderboardResponseModel
                    {
                        ClassName = RemoveClassSuffix(c.ClassName),
                        State = c.State,
                        DisplayName = GetInitialName(c.DisplayName),
                        SchoolCode = c.SchoolCode,
                        Dna = c.Dna,
                        PlayerId = c.PlayerId,
                        SchoolName = c.SchoolCode == "SIN" ? "Skoolbo International" : c.SchoolName,
                        Score = c.Score,
                        Region = c.Region,
                    };

                    return item;
                }).ToList();
        }

        private static string GetInitialName(string str, string separator = "")
        {
            var displayName = string.Empty;
            if (!string.IsNullOrEmpty(str))
            {
                var splitName = str.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var nameItem in splitName)
                {
                    if (!string.IsNullOrEmpty(nameItem))
                    {
                        displayName += nameItem.Substring(0, 1).ToUpper() + separator;
                    }
                }
            }
            return displayName;
        }

        private static string RemoveClassSuffix(string str)
        {
            if (string.IsNullOrEmpty(str) || str == "@SB") return string.Empty;

            str = str.Trim();

            var rgx = new Regex("(@[0-9]{4})$");
            return rgx.Replace(str, string.Empty).ToUpper();
        }

    }
}