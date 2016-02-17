using System.Collections.Generic;
using System.Web;
using Ca.Skoolbo.Homesite.Resources;
using Ca.Skoolbo.Homesite.Helpers;

namespace Ca.Skoolbo.Homesite.Models
{
    public class ModelBase
    {
        public static string DnaImageUrl(string dna, bool bg = true)
        {
            if (string.IsNullOrEmpty(dna))
            {
                return Assets.AvatarMaleDefault;
            }

            string[] settings = dna.Split('|');

            string portraitKey = settings[0];

            var countValid = 0;
            foreach (string part in DnaParts())
            {
                for (int i = 1; i < settings.Length; i = i + 2)
                {
                    if (settings[i].Equals(part))
                    {
                        portraitKey += "|" + part + "|" + settings[i + 1];
                        countValid++;
                        break;
                    }
                }
            }
            if (countValid < 5)
                return VirtualPathUtility.ToAbsolute("~/Images/Default-Avatar.png");

            portraitKey = portraitKey.Md5();

            if (bg)
                return string.Format(Assets.Avatar128, portraitKey);

            return string.Format(Assets.Avatar128NoBackground, portraitKey);
        }

        public static string DnaImagePortraitKey(string dna)
        {
            if (string.IsNullOrEmpty(dna))
            {
                return VirtualPathUtility.ToAbsolute("~/Images/Default-Avatar.png");
            }

            string[] settings = dna.Split('|');

            string portraitKey = settings[0];

            var countValid = 0;
            foreach (string part in DnaParts())
            {
                for (int i = 1; i < settings.Length; i = i + 2)
                {
                    if (settings[i].Equals(part))
                    {
                        portraitKey += "|" + part + "|" + settings[i + 1];
                        countValid++;
                        break;
                    }
                }
            }
            if (countValid < 5)
                return VirtualPathUtility.ToAbsolute("~/Images/Default-Avatar.png");

            portraitKey = portraitKey.Md5();
            return portraitKey;
        }

        public static IEnumerable<string> DnaParts()
        {
            return new List<string>
            {
                "eyes",
                "hair",
                "head",
                "skin",
                "top"
            };
        }
    }
}