namespace SkillUp.Infrastructure.Models;

public class UserSkill
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public Guid SkillId { get; set; }
    public Skill Skill { get; set; } = null!;
    public int Level { get; set; } // 1-5
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
