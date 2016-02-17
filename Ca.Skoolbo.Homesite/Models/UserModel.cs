using System.ComponentModel.DataAnnotations;
using Ca.Skoolbo.Homesite.Extensions;
using Ca.Skoolbo.Homesite.Resources;

namespace Ca.Skoolbo.Homesite.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = @"First name is required.")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = @"Email is required.")]
        [RegularExpressionCustom("RexEmail", typeof(ResourceRegex), "MesEmail", typeof(ResourceRegex))]
        public string Email { get; set; }
    }
}