using SchoolMedical.Repositories.HoaLQ;
using SchoolMedical.Repositories.HoaLQ.Models;

namespace SchoolMedical.Services.HoaLQ;

public interface IHealthProfilesHoaLqService
{
    Task<List<HealthProfilesHoaLq>> GetAllAsync();
    Task<HealthProfilesHoaLq> GetByIdAsync(int id);
    Task<List<HealthProfilesHoaLq>> SearchAsync(string bloodType, string searchCode, int sight);
    Task<int> CreateAsync(HealthProfilesHoaLq healthProfilesHoaLq);
    Task<int> UpdateAsync(HealthProfilesHoaLq healthProfilesHoaLq);
    Task<bool> RemoveAsync(int id);
}
public class HealthProfilesHoaLqService: IHealthProfilesHoaLqService
{
    private readonly HealthProfilesHoaLqRepository _healthProfilesHoaLqRepository;
    
    public HealthProfilesHoaLqService() => _healthProfilesHoaLqRepository ??= new HealthProfilesHoaLqRepository();

    public async Task<List<HealthProfilesHoaLq>> GetAllAsync()
    {
        return await _healthProfilesHoaLqRepository.GetAllAsync();
    }
    
    public async Task<HealthProfilesHoaLq> GetByIdAsync(int id)
    {
        return await _healthProfilesHoaLqRepository.GetByIdAsync(id);
    }
    
    public async Task<List<HealthProfilesHoaLq>> SearchAsync(string bloodType, string searchCode, int sight)
    {
        return await _healthProfilesHoaLqRepository.SearchAsync(bloodType, searchCode, sight);
    }
    
    public async Task<int> CreateAsync(HealthProfilesHoaLq healthProfilesHoaLq)
    {
        var createdProfile = await _healthProfilesHoaLqRepository.CreateAsync(healthProfilesHoaLq);
        return createdProfile;
    }
    
    public async Task<int> UpdateAsync(HealthProfilesHoaLq healthProfilesHoaLq)
    {
        var updatedProfile = await _healthProfilesHoaLqRepository.UpdateAsync(healthProfilesHoaLq);
        return updatedProfile;
    }
    
    public async Task<bool> RemoveAsync(int id)
    {
        var removedProfile = await _healthProfilesHoaLqRepository.GetByIdAsync(id);
        return await _healthProfilesHoaLqRepository.RemoveAsync(removedProfile);
    }
}