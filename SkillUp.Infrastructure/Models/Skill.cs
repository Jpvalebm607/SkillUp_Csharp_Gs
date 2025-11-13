namespace SkillUp.Infrastructure.Models;

public class Skill
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = null!;
    public ICollection<UserSkill> UserSkills { get; set; } = new List<UserSkill>();
}
