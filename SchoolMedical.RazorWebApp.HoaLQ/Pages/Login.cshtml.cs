using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolMedical.Services.HoaLQ;

namespace SchoolMedical.RazorWebApp.HoaLQ.Pages;

[AllowAnonymous]

public class LoginModel : PageModel
{
    private readonly ISystemUserAccountService _systemUserAccountService;
    public LoginModel(ISystemUserAccountService systemUserAccountService)
    {
        _systemUserAccountService = systemUserAccountService;
    }
    [BindProperty]
    public string UserName { get; set; } = string.Empty;

    [BindProperty]
    public string Password { get; set; } = string.Empty;


    public string ErrorMessage { get; set; }

    public class InputModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }


    public async Task<IActionResult> OnPost()
    {
       
        var user = await _systemUserAccountService.GetUserByUserNameAndPassword(UserName, Password);
        if (user != null)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,UserName),
                new Claim(ClaimTypes.Role, user.RoleId.ToString())
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal).Wait();
            Response.Cookies.Append("FullName", user.FullName);
            return RedirectToPage("/Index");
        }

        ErrorMessage = "Sai tên đăng nhập hoặc mật khẩu.";
       await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Page();
    }
}