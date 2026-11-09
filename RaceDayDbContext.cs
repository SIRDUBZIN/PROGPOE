using Microsoft.EntityFrameworkCore;
using RaceDay.Api.Models;
namespace RaceDay.Api.Data;
public class RaceDayDbContext(DbContextOptions<RaceDayDbContext> options) : DbContext(options)
{
 public DbSet<RaceEvent> Events => Set<RaceEvent>();
 public DbSet<RaceCategory> Categories => Set<RaceCategory>();
 public DbSet<RaceEnrollment> Enrollments => Set<RaceEnrollment>();
 public DbSet<RaceResult> Results => Set<RaceResult>();
 protected override void OnModelCreating(ModelBuilder b) {
  b.Entity<RaceEnrollment>().HasIndex(x => new { x.ParticipantId, x.EventId }).IsUnique();
  b.Entity<RaceResult>().HasIndex(x => x.EnrollmentId).IsUnique();
  b.Entity<RaceCategory>().HasOne(x=>x.Event).WithMany(x=>x.Categories).HasForeignKey(x=>x.EventId).OnDelete(DeleteBehavior.Cascade);
  b.Entity<RaceEnrollment>().HasOne(x=>x.Event).WithMany(x=>x.Enrollments).HasForeignKey(x=>x.EventId).OnDelete(DeleteBehavior.Restrict);
 }
}
