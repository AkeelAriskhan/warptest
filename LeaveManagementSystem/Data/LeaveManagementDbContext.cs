using Microsoft.EntityFrameworkCore;
using LeaveManagementSystem.Models;

namespace LeaveManagementSystem.Data
{
    public class LeaveManagementDbContext : DbContext
    {
        public LeaveManagementDbContext(DbContextOptions<LeaveManagementDbContext> options)
            : base(options)
        {
        }

        // DbSets for all entities
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<CompanyHoliday> CompanyHolidays { get; set; }
        public DbSet<CompanyWeekendPolicy> CompanyWeekendPolicies { get; set; }
        public DbSet<SpecialLeave> SpecialLeaves { get; set; }
        public DbSet<LeaveRequestGroup> LeaveRequestGroups { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<LeaveBalance> LeaveBalances { get; set; }
        public DbSet<LeaveApproval> LeaveApprovals { get; set; }
        public DbSet<LeaveBalanceHistory> LeaveBalanceHistories { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships and constraints

            // User-Employee one-to-one relationship
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.User)
                .WithOne(u => u.Employee)
                .HasForeignKey<Employee>(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Employee self-referencing relationship (Manager-Subordinate)
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Manager)
                .WithMany(e => e.Subordinates)
                .HasForeignKey(e => e.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Department-Employee relationship
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Department head relationship
            modelBuilder.Entity<Department>()
                .HasOne(d => d.DepartmentHead)
                .WithMany()
                .HasForeignKey(d => d.DepartmentHeadId)
                .OnDelete(DeleteBehavior.SetNull);

            // Leave Request Group - Employee relationship
            modelBuilder.Entity<LeaveRequestGroup>()
                .HasOne(lg => lg.Employee)
                .WithMany(e => e.LeaveRequestGroups)
                .HasForeignKey(lg => lg.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Leave Request - Leave Request Group relationship
            modelBuilder.Entity<LeaveRequest>()
                .HasOne(lr => lr.RequestGroup)
                .WithMany(lg => lg.LeaveRequests)
                .HasForeignKey(lr => lr.RequestGroupId)
                .OnDelete(DeleteBehavior.Cascade);

            // Leave Request - Leave Type relationship
            modelBuilder.Entity<LeaveRequest>()
                .HasOne(lr => lr.LeaveType)
                .WithMany(lt => lt.LeaveRequests)
                .HasForeignKey(lr => lr.LeaveTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Leave Balance relationships
            modelBuilder.Entity<LeaveBalance>()
                .HasOne(lb => lb.Employee)
                .WithMany(e => e.LeaveBalances)
                .HasForeignKey(lb => lb.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LeaveBalance>()
                .HasOne(lb => lb.LeaveType)
                .WithMany(lt => lt.LeaveBalances)
                .HasForeignKey(lb => lb.LeaveTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Leave Approval relationships
            modelBuilder.Entity<LeaveApproval>()
                .HasOne(la => la.RequestGroup)
                .WithMany(lg => lg.LeaveApprovals)
                .HasForeignKey(la => la.RequestGroupId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LeaveApproval>()
                .HasOne(la => la.Approver)
                .WithMany(e => e.LeaveApprovals)
                .HasForeignKey(la => la.ApproverId)
                .OnDelete(DeleteBehavior.Restrict);

            // Leave Balance History relationships
            modelBuilder.Entity<LeaveBalanceHistory>()
                .HasOne(lbh => lbh.Employee)
                .WithMany()
                .HasForeignKey(lbh => lbh.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LeaveBalanceHistory>()
                .HasOne(lbh => lbh.LeaveType)
                .WithMany()
                .HasForeignKey(lbh => lbh.LeaveTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LeaveBalanceHistory>()
                .HasOne(lbh => lbh.ChangedByEmployee)
                .WithMany()
                .HasForeignKey(lbh => lbh.ChangedBy)
                .OnDelete(DeleteBehavior.Restrict);

            // Notification relationships
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.Employee)
                .WithMany()
                .HasForeignKey(n => n.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Unique constraints
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<LeaveBalance>()
                .HasIndex(lb => new { lb.EmployeeId, lb.LeaveTypeId, lb.Year })
                .IsUnique();

            // Seed data for User Roles
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { RoleId = 1, RoleName = "Employee", CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new UserRole { RoleId = 2, RoleName = "Manager", CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new UserRole { RoleId = 3, RoleName = "HR_Admin", CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new UserRole { RoleId = 4, RoleName = "Super_Admin", CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) }
            );

            // Seed data for Leave Types
            modelBuilder.Entity<LeaveType>().HasData(
                new LeaveType { LeaveTypeId = 1, LeaveTypeName = "Annual Leave", Description = "Yearly vacation leave", MaxDaysPerYear = 21, IsPaidLeave = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new LeaveType { LeaveTypeId = 2, LeaveTypeName = "Sick Leave", Description = "Medical leave", MaxDaysPerYear = 10, IsPaidLeave = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new LeaveType { LeaveTypeId = 3, LeaveTypeName = "Maternity Leave", Description = "Maternity leave", MaxDaysPerYear = 90, IsPaidLeave = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new LeaveType { LeaveTypeId = 4, LeaveTypeName = "Personal Leave", Description = "Personal time off", MaxDaysPerYear = 5, IsPaidLeave = false, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) }
            );
        }

        public override int SaveChanges()
        {
            UpdateTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateTimestamps()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    if (entry.Property("CreatedAt").CurrentValue == null)
                        entry.Property("CreatedAt").CurrentValue = DateTime.UtcNow;
                }

                if (entry.Property("UpdatedAt") != null)
                    entry.Property("UpdatedAt").CurrentValue = DateTime.UtcNow;
            }
        }
    }
}
