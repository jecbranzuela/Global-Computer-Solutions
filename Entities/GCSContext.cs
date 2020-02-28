using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using GCSClasses.EFClasses;
using GCSClasses.EFConfig;
using Microsoft.EntityFrameworkCore;

namespace GCSClasses
{
    public class GcsContext :DbContext
    {
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkills { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectSchedule> ProjectSchedules { get; set; }
        public DbSet<ProjectScheduleTask> ProjectScheduleTasks { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<TaskClass> TaskClasses { get; set; }
        public DbSet<TaskSkill> TaskSkills { get; set; }
        public DbSet<WorkLog> WorkLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GlobalComputerSolutions;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AssignmentConfig());
            modelBuilder.ApplyConfiguration(new BillConfig());
            modelBuilder.ApplyConfiguration(new CustomerConfig());
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
            modelBuilder.ApplyConfiguration(new EmployeeSkillConfig());
            modelBuilder.ApplyConfiguration(new ProjectConfig());
            modelBuilder.ApplyConfiguration(new ProjectScheduleConfig());
            modelBuilder.ApplyConfiguration(new ProjectScheduleTaskConfig());
            modelBuilder.ApplyConfiguration(new RegionConfig());
            modelBuilder.ApplyConfiguration(new SkillConfig());
            modelBuilder.ApplyConfiguration(new TaskClassConfig());
            modelBuilder.ApplyConfiguration(new TaskSkillConfig());
            modelBuilder.ApplyConfiguration(new WorkLogConfig());
        }
    }
}
