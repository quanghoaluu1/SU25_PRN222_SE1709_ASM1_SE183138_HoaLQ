using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolMedical.Repositories.HoaLQ.Basic;
using SchoolMedical.Repositories.HoaLQ.Models;

namespace SchoolMedical.Repositories.HoaLQ
{
    public class HealthProfilesHoaLqRepository: GenericRepository<HealthProfilesHoaLq>
    {
        public HealthProfilesHoaLqRepository()
        {
            _context ??= new SU25_PRN222_SE1709_G1_SchoolMedicalContext();
        }

        public HealthProfilesHoaLqRepository(SU25_PRN222_SE1709_G1_SchoolMedicalContext context)
        {
            _context = context;
        }
        
        public new async Task< List<HealthProfilesHoaLq>> GetAllAsync()
        {
            return await _context.HealthProfilesHoaLqs
                .Include(h => h.Student)
                .ToListAsync() ?? new List<HealthProfilesHoaLq>();
        }

        public async Task<HealthProfilesHoaLq> GetByIdAsync(int id)
        {
            var healthProfile = await _context.HealthProfilesHoaLqs
                .Include(h => h.Student)
                .FirstOrDefaultAsync(h => h.HealthProfileHoaLqid == id);
            return healthProfile ?? new HealthProfilesHoaLq();
        }

        public async Task<List<HealthProfilesHoaLq>> SearchAsync(string bloodType, string searchCode, int sight)
        {
            var healthProfiles = await _context.HealthProfilesHoaLqs.Include(h => h.Student).Where(h => (h.BloodType.Contains(bloodType) || string.IsNullOrEmpty(bloodType))
            && (h.Student.StudentCode.Contains(searchCode) || string.IsNullOrEmpty(searchCode))
            && (h.Sight == sight || sight == 0))
                .ToListAsync();

            return healthProfiles ?? new List<HealthProfilesHoaLq>();
        }
    }
}
