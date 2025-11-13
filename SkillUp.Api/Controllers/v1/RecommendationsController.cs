using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillUp.Infrastructure.Data;

namespace SkillUp.Api.Controllers.v1;

[ApiController]
[Route("api/v{version:apiVersion}/recommendations")]
[ApiVersion("1.0")]
public class RecommendationsController : ControllerBase
{
    private readonly SkillUpDbContext _db;
    public RecommendationsController(SkillUpDbContext db) => _db = db;

    [HttpGet("{userId:guid}")]
    public async Task<IActionResult> Recommend(Guid userId)
    {
        var user = await _db.Users.Include(u => u.Skills).ThenInclude(us => us.Skill)
                                  .FirstOrDefaultAsync(u => u.Id == userId);
        if (user is null) return NotFound();

        var weakest = user.Skills.OrderBy(us => us.Level).Select(us => us.Skill.Name).FirstOrDefault();
        var courses = await _db.Courses.Where(c => c.TargetSkill == weakest).ToListAsync();

        return Ok(new { userId, targetSkill = weakest, recommended = courses });
    }
}
