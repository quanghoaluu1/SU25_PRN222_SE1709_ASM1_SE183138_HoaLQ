
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using SchoolMedical.Repositories.HoaLQ.DTO;
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
        var result = await _healthProfilesHoaLqService.CreateAsync(item);
        await Clients.All.SendAsync("Receiver_CreateHealthProfile", result);

    }
    
    public async Task HubUpdate_HealthProfile(string healthProfileHoaLqIdJsonString)
    {
        try
        {
            var item = JsonConvert.DeserializeObject<HealthProfilesHoaLq>(healthProfileHoaLqIdJsonString);
            var result = await _healthProfilesHoaLqService.UpdateAsync(item);
            await Clients.All.SendAsync("Receiver_UpdateHealthProfile", result);

        }
        catch (Exception ex)
        {
            Console.WriteLine("SignalR Error: " + ex.Message);
            throw;
        }
    }
    public async Task HubSearch_HealthProfiles(string studentName, string bloodType, bool? sex, int? minWeight, int? maxWeight, int? minHeight, int? maxHeight, int pageNumber, int pageSize)
    {
        var searchResult = await _healthProfilesHoaLqService.SearchAsync(
            studentName, bloodType, sex, minWeight, maxWeight, minHeight, maxHeight, pageNumber, pageSize); 
        var resultDto = searchResult.Select(p => new HealthProfileDTO()
        {
            HealthProfileHoaLqid = p.HealthProfileHoaLqid,
            Weight = p.Weight,
            Height = p.Height,
            Sight = p.Sight,
            Hearing = p.Hearing,
            BloodType = p.BloodType,
            Sex = p.Sex,
            DateOfBirth = p.DateOfBirth,
            StudentFullName = p.Student != null ? p.Student.StudentFullName : "Không rõ"
        }).ToList();
        var response = new
        {
            Items = resultDto,
            PageIndex = searchResult.PageIndex,
            TotalPages = searchResult.TotalPages,
            HasPreviousPage = searchResult.HasPreviousPage,
            HasNextPage = searchResult.HasNextPage
        };
        await Clients.Caller.SendAsync("Receive_SearchHealthProfile", response);
    }
    #endregion
}