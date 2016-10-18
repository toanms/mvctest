using System.ComponentModel.DataAnnotations;
using Ca.Skoolbo.Homesite.Extensions;
using Ca.Skoolbo.Homesite.Resources;

namespace Ca.Skoolbo.Homesite.Models
{
    public class SubscribeModel
    {
        [Required(ErrorMessage = @"Invaild Email ")]
        [RegularExpressionCustom("EmailValid", typeof(RegexValidation), "EmailMessage", typeof(RegexValidation))]
        public string Email { get; set; }
    }
}