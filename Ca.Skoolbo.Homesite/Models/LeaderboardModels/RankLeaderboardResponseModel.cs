using Ca.Skoolbo.Homesite.Helpers.Configs;
using Ca.Skoolbo.Homesite.Resources;

namespace Ca.Skoolbo.Homesite.Models.LeaderboardModels
{
   public class RankLeaderboardResponseModel
    {
 
        public string ClassName { get; set; }


        public string DisplayName { get; set; }


        public string Dna { get; set; }


        public string PlayerId { get; set; }


        public string SchoolCode { get; set; }


        public string SchoolName { get; set; }


        public int Score { get; set; }

 
        public string State { get; set; }

   
        public string StateId { get; set; }

  
        public string Region { get; set; }

        public string ProfileImageDefaultUrl
        {
            get { return Assets.AvatarMaleDefault; }
        }

        public string ProfileImageUrl
        {
            get { return ModelBase.DnaImageUrl(Dna); }
        }

        public string CountryLogoUrl
        {
            get
            {
                var region = (Region ?? WebConfigHelper.FolderImageS3.ToUpper()).ToUpper();

                return string.Format(Assets.State, region, region);
                //return string.Format(Assets.State, WebConfigHelper.FolderImageS3.ToUpper(), Region.ToUpper());
            }
        }

        public string SchoolStateLogoUrl
        {
            get
            {
                return string.Format(Assets.State, (Region?? WebConfigHelper.FolderImageS3.ToUpper()).ToUpper(), string.IsNullOrEmpty(State) ? "SIN" : State.Trim().ToUpper());
            }
        }

        public string StateDefault
        {
            get
            {
                return string.Format(Assets.State, WebConfigHelper.FolderImageS3.ToUpper(), "SIN");
            }
        }
    }
}
