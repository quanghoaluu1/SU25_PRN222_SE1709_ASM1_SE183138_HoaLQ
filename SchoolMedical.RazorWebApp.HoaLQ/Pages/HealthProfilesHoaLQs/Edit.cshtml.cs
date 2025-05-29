using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolMedical.Repositories.HoaLQ.Models;
using SchoolMedical.Services.HoaLQ;

namespace SchoolMedical.RazorWebApp.HoaLQ.Pages.HealthProfilesHoaLQs
{
    [Authorize(Roles = "1,2")]
    public class EditModel : PageModel
    {
        private readonly IHealthProfilesHoaLqService _healthProfilesHoaLqService;
        public EditModel(IHealthProfilesHoaLqService healthProfilesHoaLqService)
        {
            _healthProfilesHoaLqService = healthProfilesHoaLqService;
        }

        [BindProperty]
        public HealthProfilesHoaLq HealthProfilesHoaLq { get; set; } = default!;
        
        public async Task OnGetAsync(int id)
        {

            HealthProfilesHoaLq = await _healthProfilesHoaLqService.GetByIdAsync(id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (HealthProfilesHoaLq != null)
            {
                await _healthProfilesHoaLqService.UpdateAsync(HealthProfilesHoaLq);
            }

            return RedirectToPage("./Index");
            
        }
        
    }
}
