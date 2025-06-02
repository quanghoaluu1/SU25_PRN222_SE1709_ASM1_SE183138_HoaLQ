
using Microsoft.AspNetCore.SignalR;
using SchoolMedical.Services.HoaLQ;

namespace SchoolMedical.RazorWebApp.HoaLQ.Hubs;

public class SchoolMedicalHub: Hub
{
    private readonly IHealthProfilesHoaLqService _healthProfilesHoaLqService;
    
    public SchoolMedicalHub(IHealthProfilesHoaLqService healthProfilesHoaLqService)
    {
        _healthProfilesHoaLqService = healthProfilesHoaLqService;
    }

    #region Hub for HealthProfiles

    public async Task HubDelete_HealthProfile(string healthProfileHoaLqId)
    {
        await Clients.All.SendAsync("Receiver_DeleteHealthProfile", healthProfileHoaLqId);
        await _healthProfilesHoaLqService.RemoveAsync(int.Parse(healthProfileHoaLqId));
    }
    #endregion
}