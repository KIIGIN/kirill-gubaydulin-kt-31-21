﻿using kirill_gubaydulin_kt_31_21.Database.Configurations;
using kirill_gubaydulin_kt_31_21.Models;
using Microsoft.EntityFrameworkCore;


namespace kirill_gubaydulin_kt_31_21.Database
{
    public class DepartmentDbContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        DbSet<Degree> Degrees { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<Discipline> Disciplines { get; set; }
        DbSet<Position> Positions { get; set; }
        DbSet<Load> Loads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new DegreeConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new DisciplineConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
            modelBuilder.ApplyConfiguration(new LoadConfiguration());
        }

        public DepartmentDbContext(DbContextOptions<DepartmentDbContext> options) : base(options) 
        { 
        }
    }
}
