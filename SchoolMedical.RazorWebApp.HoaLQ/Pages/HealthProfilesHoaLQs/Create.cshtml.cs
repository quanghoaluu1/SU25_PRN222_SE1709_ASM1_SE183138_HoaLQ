using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolMedical.Repositories.HoaLQ.Models;
using SchoolMedical.Services.HoaLQ;

namespace SchoolMedical.RazorWebApp.HoaLQ.Pages.HealthProfilesHoaLQs
{
    [Authorize(Roles = "1,2")]
    public class CreateModel : PageModel
    {
        #region  Use Services
        
        private readonly IHealthProfilesHoaLqService _healthProfilesHoaLqService;
        private readonly IStudentHoaLQService _studentHoaLQService;
        public CreateModel(IHealthProfilesHoaLqService healthProfilesHoaLqService, IStudentHoaLQService studentHoaLQService)
        {
            _healthProfilesHoaLqService = healthProfilesHoaLqService;
            _studentHoaLQService = studentHoaLQService;
        }

        [BindProperty]
        public HealthProfilesHoaLq HealthProfilesHoaLq { get; set; } = default!;
        [BindProperty]
        public List<StudentsHoaLq> StudentsHoaLq { get; set; } = default!;
        
        public SelectList StudentSelectList { get; set; }
        public async Task OnGetAsync()
        {
            StudentsHoaLq = await _studentHoaLQService.GetAllAsync();
            StudentSelectList = new SelectList(StudentsHoaLq, "StudentsHoaLqid", "StudentFullName");
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await _healthProfilesHoaLqService.CreateAsync(HealthProfilesHoaLq);
            return RedirectToPage("./Index");
        }
        #endregion

    }
}
