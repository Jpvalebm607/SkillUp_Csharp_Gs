using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillUp.Infrastructure.Data;
using SkillUp.Infrastructure.Models;

namespace SkillUp.Api.Controllers.v1;

[ApiController]
[Route("api/v{version:apiVersion}/users/{userId:guid}/skills")]
[ApiVersion("1.0")]
public class UserSkillsController : ControllerBase
{
    private readonly SkillUpDbContext _db;
    public UserSkillsController(SkillUpDbContext db) => _db = db;

    public record UpsertUserSkillDto(string SkillName, int Level);

    [HttpPost]
    public async Task<IActionResult> Upsert(Guid userId, [FromBody] UpsertUserSkillDto dto)
    {
        if (dto.Level is < 1 or > 5) return BadRequest(new { error = "Level must be 1-5" });

        var user = await _db.Users.FindAsync(userId);
        if (user is null) return NotFound(new { error = "User not found" });

        var skill = await _db.Skills.FirstOrDefaultAsync(s => s.Name == dto.SkillName)
                    ?? _db.Skills.Add(new Skill { Name = dto.SkillName }).Entity;

        var existing = await _db.UserSkills.FindAsync(userId, skill.Id);
        if (existing is null)
            _db.UserSkills.Add(new UserSkill { UserId = userId, SkillId = skill.Id, Level = dto.Level });
        else
            existing.Level = dto.Level;

        await _db.SaveChangesAsync();
        return NoContent();
    }
}
