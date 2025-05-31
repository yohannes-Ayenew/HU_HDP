using Microsoft.EntityFrameworkCore;
using HU_HDP.Models;

namespace HU_HDP.Data
{
    public class HDPDbContext : DbContext
    {
        public HDPDbContext(DbContextOptions<HDPDbContext> options)
            : base(options)
        {
        }

        public DbSet<AcademicUnit> AcademicUnits { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Center> Centers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<TraineeAssignment> TraineeAssignments { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WeeklySchedule> WeeklySchedules { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ActionResearch> ActionResearches { get; set; }

    


    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Trainer)
                .WithMany(t => t.Attendances)
                .HasForeignKey(a => a.TrainerId)
                .OnDelete(DeleteBehavior.Restrict); // ✅ FIX: Prevent cascade delete here

            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Trainee)
                .WithMany(t => t.Attendances)
                .HasForeignKey(a => a.TraineeId)
                .OnDelete(DeleteBehavior.Restrict); // ✅ Optional: You can pick either one

            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.WeeklySchedule)
                .WithMany(ws => ws.Attendances)
                .HasForeignKey(a => a.WeeklyScheduleId)
                .OnDelete(DeleteBehavior.Cascade); // This can still cascade
        }
    } }