using System.ComponentModel.DataAnnotations;

namespace AspNetCoreAuth2.Pages.Account
{
    public class LoginInputModel
    {
        [Required]
        [MinLength(5)]
        public string UserName { get; set; }
        [Required]
        [MinLength(5)]
        public string Password { get; set; }
    }
}
