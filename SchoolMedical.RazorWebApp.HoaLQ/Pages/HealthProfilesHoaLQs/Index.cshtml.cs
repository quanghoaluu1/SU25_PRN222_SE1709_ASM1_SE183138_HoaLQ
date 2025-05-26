using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolMedical.Repositories.HoaLQ.Models;
using SchoolMedical.Services.HoaLQ;

namespace SchoolMedical.RazorWebApp.HoaLQ.Pages.HealthProfilesHoaLQs
{
    public class IndexModel : PageModel
    {
        private readonly IHealthProfilesHoaLqService _healthProfilesHoaLqService;
        public IndexModel(IHealthProfilesHoaLqService healthProfilesHoaLqService)
        {
            _healthProfilesHoaLqService = healthProfilesHoaLqService;
        }

        public IList<HealthProfilesHoaLq> HealthProfilesHoaLq { get; set; } = default!;

        public async Task OnGetAsync()
        {
            HealthProfilesHoaLq = await _healthProfilesHoaLqService.GetAllAsync();
        }
    }
}
