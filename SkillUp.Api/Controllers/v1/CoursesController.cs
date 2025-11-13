using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillUp.Infrastructure.Data;

namespace SkillUp.Api.Controllers.v1;

[ApiController]
[Route("api/v{version:apiVersion}/courses")]
[ApiVersion("1.0")]
public class CoursesController : ControllerBase
{
    private readonly SkillUpDbContext _db;
    public CoursesController(SkillUpDbContext db) => _db = db;

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string? skill = null)
    {
        var q = _db.Courses.AsQueryable();
        if (!string.IsNullOrWhiteSpace(skill)) q = q.Where(c => c.TargetSkill == skill);
        return Ok(await q.OrderBy(c => c.Title).ToListAsync());
    }
}
