using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SchoolMedical.RazorWebApp.HoaLQ.Pages;

public class LogoutModel : PageModel
{
    public async Task<IActionResult> OnGet()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        if (Request.Cookies.TryGetValue("FullName", out var fullName))
        {
            Response.Cookies.Delete("FullName");
        }
        return RedirectToPage("/Index");
    }
}