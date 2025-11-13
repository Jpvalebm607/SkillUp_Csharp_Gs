namespace SkillUp.Infrastructure.Models;

public class Course
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = null!;
    public string Provider { get; set; } = "External";
    public string Url { get; set; } = null!;
    public string TargetSkill { get; set; } = null!;
    public string Difficulty { get; set; } = "Beginner";
    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
