using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AspNetCoreAuth2.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LoginInputModel LoginInputModel {get;set;}

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (!IsUserAuthenticated(LoginInputModel.UserName, LoginInputModel.Password))
            {
                ModelState.AddModelError(string.Empty, "Usúario ou senha inválidos");
                return Page();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, LoginInputModel.UserName)
            };

            var userIdentity = new ClaimsIdentity(claims, "login");
            var principal = new ClaimsPrincipal(userIdentity);

            await HttpContext.SignInAsync(principal);
            return Redirect("/");
        }

        public async Task<IActionResult> OnPostLogout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        private bool IsUserAuthenticated(string userName, string password)
        {
            //simulação de autenticação no banco de dados.
            return true;
        }
    }
}