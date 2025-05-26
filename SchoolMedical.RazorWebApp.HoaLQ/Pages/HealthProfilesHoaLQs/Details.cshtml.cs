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
    public class DetailsModel : PageModel
    {

        private readonly IHealthProfilesHoaLqService _healthProfilesHoaLqService;
        public DetailsModel(IHealthProfilesHoaLqService healthProfilesHoaLqService)
        {
            _healthProfilesHoaLqService = healthProfilesHoaLqService;
        }
        public HealthProfilesHoaLq HealthProfilesHoaLq { get; set; } = default!;

        public async Task OnGetAsync(int id)
        {

            HealthProfilesHoaLq = await _healthProfilesHoaLqService.GetByIdAsync(id);
        }

    }
}
