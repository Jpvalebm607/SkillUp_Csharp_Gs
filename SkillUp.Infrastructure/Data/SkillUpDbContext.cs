using Microsoft.EntityFrameworkCore;
using SkillUp.Infrastructure.Models;

namespace SkillUp.Infrastructure.Data;

public class SkillUpDbContext : DbContext
{
    public SkillUpDbContext(DbContextOptions<SkillUpDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Skill> Skills => Set<Skill>();
    public DbSet<UserSkill> UserSkills => Set<UserSkill>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Enrollment> Enrollments => Set<Enrollment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(b => { b.HasIndex(u => u.Email).IsUnique(); });

        modelBuilder.Entity<UserSkill>(b =>
        {
            b.HasKey(us => new { us.UserId, us.SkillId });
            b.HasOne(us => us.User).WithMany(u => u.Skills).HasForeignKey(us => us.UserId);
            b.HasOne(us => us.Skill).WithMany(s => s.UserSkills).HasForeignKey(us => us.SkillId);
        });

        modelBuilder.Entity<Enrollment>(b =>
        {
            b.HasOne(e => e.User).WithMany(u => u.Enrollments).HasForeignKey(e => e.UserId);
            b.HasOne(e => e.Course).WithMany(c => c.Enrollments).HasForeignKey(e => e.CourseId);
        });
    }
}
