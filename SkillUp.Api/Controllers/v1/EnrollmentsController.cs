using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillUp.Infrastructure.Data;
using SkillUp.Infrastructure.Models;

namespace SkillUp.Api.Controllers.v1;

[ApiController]
[Route("api/v{version:apiVersion}/enrollments")]
[ApiVersion("1.0")]
public class EnrollmentsController : ControllerBase
{
    private readonly SkillUpDbContext _db;
    public EnrollmentsController(SkillUpDbContext db) => _db = db;

    public record EnrollDto(Guid UserId, Guid CourseId);

    [HttpPost]
    public async Task<IActionResult> Enroll([FromBody] EnrollDto dto)
    {
        var user = await _db.Users.FindAsync(dto.UserId);
        var course = await _db.Courses.FindAsync(dto.CourseId);
        if (user is null || course is null) return NotFound(new { error = "User or Course not found" });

        var exists = await _db.Enrollments.AnyAsync(e => e.UserId == dto.UserId && e.CourseId == dto.CourseId);
        if (exists) return Conflict(new { error = "Already enrolled" });

        _db.Enrollments.Add(new Enrollment { UserId = dto.UserId, CourseId = dto.CourseId });
        await _db.SaveChangesAsync();
        return StatusCode(201);
    }
}
