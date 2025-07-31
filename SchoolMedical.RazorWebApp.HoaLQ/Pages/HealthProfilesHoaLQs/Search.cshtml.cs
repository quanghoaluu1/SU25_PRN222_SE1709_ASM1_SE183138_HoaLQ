using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolMedical.Repositories.HoaLQ.Models;
using SchoolMedical.Services.HoaLQ;

namespace SchoolMedical.RazorWebApp.HoaLQ.Pages.HealthProfilesHoaLQs;

public class SearchModel : PageModel
{
    private readonly IHealthProfilesHoaLqService _healthProfilesHoaLqService;
      
    public SearchModel(IHealthProfilesHoaLqService healthProfilesHoaLqService)
    {
        _healthProfilesHoaLqService = healthProfilesHoaLqService;
    }

    public IList<HealthProfilesHoaLq> HealthProfilesHoaLq { get; set; } = default!;
  
    [BindProperty(SupportsGet = true)]
    public string? StudentName { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? BloodType { get; set; }

    [BindProperty(SupportsGet = true)]
    public bool? Sex { get; set; }

    [BindProperty(SupportsGet = true)]
    public int? MinWeight { get; set; }

    [BindProperty(SupportsGet = true)]
    public int? MaxWeight { get; set; }

    [BindProperty(SupportsGet = true)]
    public int? MinHeight { get; set; }

    [BindProperty(SupportsGet = true)]
    public int? MaxHeight { get; set; }
    public async Task OnGetAsync(int pageNumber = 1, int pageSize = 5)
    {
        bool isSearch = !string.IsNullOrEmpty(StudentName) || !string.IsNullOrEmpty(BloodType) || Sex.HasValue ||
                        MinWeight.HasValue || MaxWeight.HasValue || MinHeight.HasValue || MaxHeight.HasValue;
        if (isSearch)
        {
            var paginatedResult = await _healthProfilesHoaLqService.SearchAsync(
                StudentName, BloodType, Sex, MinWeight, MaxWeight, MinHeight, MaxHeight, pageNumber, pageSize);
            HealthProfilesHoaLq = paginatedResult;
        }
        else
        {
            HealthProfilesHoaLq = await _healthProfilesHoaLqService.GetAllAsync(pageNumber, pageSize);
        }
    }
}