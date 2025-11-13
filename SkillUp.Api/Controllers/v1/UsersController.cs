using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillUp.Infrastructure.Data;
using SkillUp.Infrastructure.Models;

namespace SkillUp.Api.Controllers.v1;

[ApiController]
[Route("api/v{version:apiVersion}/users")]
[ApiVersion("1.0")]
public class UsersController : ControllerBase
{
    private readonly SkillUpDbContext _db;
    public UsersController(SkillUpDbContext db) => _db = db;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] User dto)
    {
        if (string.IsNullOrWhiteSpace(dto.FullName) || string.IsNullOrWhiteSpace(dto.Email))
            return UnprocessableEntity(new { error = "FullName and Email are required" });

        var exists = await _db.Users.AnyAsync(u => u.Email == dto.Email);
        if (exists) return Conflict(new { error = "Email already exists" });

        _db.Users.Add(dto);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = dto.Id, version = "1.0" }, dto);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var user = await _db.Users
            .Include(u => u.Skills).ThenInclude(us => us.Skill)
            .Include(u => u.Enrollments).ThenInclude(e => e.Course)
            .FirstOrDefaultAsync(u => u.Id == id);

        return user is null ? NotFound() : Ok(user);
    }
}
