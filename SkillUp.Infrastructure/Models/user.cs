namespace SkillUp.Infrastructure.Models;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Goal { get; set; }
    public ICollection<UserSkill> Skills { get; set; } = new List<UserSkill>();
    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
