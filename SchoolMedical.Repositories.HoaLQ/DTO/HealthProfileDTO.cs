namespace SchoolMedical.Repositories.HoaLQ.DTO;

public class HealthProfileDTO
{
    public int HealthProfileHoaLqid { get; set; }
    public decimal? Weight { get; set; }
    public decimal? Height { get; set; }
    public int? Sight { get; set; }
    public int? Hearing { get; set; }
    public string BloodType { get; set; }
    public bool Sex { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public string StudentFullName { get; set; }
}