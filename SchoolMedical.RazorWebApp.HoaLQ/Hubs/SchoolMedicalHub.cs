
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using SchoolMedical.Repositories.HoaLQ.Models;
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

    public async Task HubCreate_HealthProfile(string healthProfileHoaLqIdJsonString)
    {
        var item = JsonConvert.DeserializeObject<HealthProfilesHoaLq>(healthProfileHoaLqIdJsonString);
        await Clients.All.SendAsync("Receiver_CreateHealthProfile", item);
        await _healthProfilesHoaLqService.CreateAsync(item);
    }
    
    public async Task HubUpdate_HealthProfile(string healthProfileHoaLqIdJsonString)
    {
        var item = JsonConvert.DeserializeObject<HealthProfilesHoaLq>(healthProfileHoaLqIdJsonString);
        await Clients.All.SendAsync("Receiver_UpdateHealthProfile", item);
        await _healthProfilesHoaLqService.UpdateAsync(item);
    }
    #endregion
}