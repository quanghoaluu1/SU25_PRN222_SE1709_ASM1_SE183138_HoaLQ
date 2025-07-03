using SchoolMedical.Repositories.HoaLQ;
using SchoolMedical.Repositories.HoaLQ.Helper;
using SchoolMedical.Repositories.HoaLQ.Models;

namespace SchoolMedical.Services.HoaLQ;

public interface IHealthProfilesHoaLqService
{
    Task<PaginatedList<HealthProfilesHoaLq>> GetAllAsync(int pageNumber, int pageSize);
    Task<HealthProfilesHoaLq> GetByIdAsync(int id);

    Task<PaginatedList<HealthProfilesHoaLq>> SearchAsync(string studentName, string bloodType, bool? sex,
        int? minWeight, int? maxWeight, int? minHeight, int? maxHealth, int pageNumber, int pageSize);
    Task<HealthProfilesHoaLq> CreateAsync(HealthProfilesHoaLq healthProfilesHoaLq);
    Task<HealthProfilesHoaLq> UpdateAsync(HealthProfilesHoaLq healthProfilesHoaLq);
    Task<bool> RemoveAsync(int id);
}
public class HealthProfilesHoaLqService: IHealthProfilesHoaLqService
{
    private readonly HealthProfilesHoaLqRepository _healthProfilesHoaLqRepository;
    
    public HealthProfilesHoaLqService() => _healthProfilesHoaLqRepository ??= new HealthProfilesHoaLqRepository();

    public async Task<PaginatedList<HealthProfilesHoaLq>> GetAllAsync(int pageNumber, int pageSize)
    {
        return await _healthProfilesHoaLqRepository.GetAllAsync(pageNumber,pageSize);
    }
    
    public async Task<PaginatedList<HealthProfilesHoaLq>> SearchAsync(string studentName, string bloodType, bool? sex, int? minWeight, int? maxWeight, int? minHeight, int? maxHealth, int pageNumber, int pageSize)
    {
        return await _healthProfilesHoaLqRepository.SearchAsync(studentName, bloodType,sex, minWeight, maxWeight, minHeight, maxHealth, pageNumber, pageSize);
    }
    
    public async Task<HealthProfilesHoaLq> GetByIdAsync(int id)
    {
        return await _healthProfilesHoaLqRepository.GetByIdAsync(id);
    }
    
    public async Task<List<HealthProfilesHoaLq>> SearchAsync(string bloodType, string searchCode, int sight)
    {
        return await _healthProfilesHoaLqRepository.SearchAsync(bloodType, searchCode, sight);
    }
    
    public async Task<HealthProfilesHoaLq> CreateAsync(HealthProfilesHoaLq healthProfilesHoaLq)
    {
        var createdProfile = await _healthProfilesHoaLqRepository.CreateAsync(healthProfilesHoaLq);
        Console.WriteLine(createdProfile);
        return createdProfile;
    }
    
    public async Task<HealthProfilesHoaLq> UpdateAsync(HealthProfilesHoaLq healthProfilesHoaLq)
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