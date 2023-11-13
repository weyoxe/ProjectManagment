using System;
using System.Collections.Generic;
using App.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.DataContext {

    public partial class PmdbContext : DbContext
    {
        public PmdbContext()
        {
        }

        public PmdbContext(DbContextOptions<PmdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<EmployeeProject> EmployeeProjects { get; set; }

        public virtual DbSet<Project> Projects { get; set; }

      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmployeeProject>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("EmployeeProject");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.EmployeeNavigation).WithMany()
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("FK_EmployeeProject_Employee");

                entity.HasOne(d => d.Employee1).WithMany()
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("FK_EmployeeProject_Project1");

                entity.HasOne(d => d.ProjectNavigation).WithMany()
                    .HasForeignKey(d => d.Project)
                    .HasConstraintName("FK_EmployeeProject_Project");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project");

                entity.Property(e => e.ExecutingCompany)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.ExpirationDate).HasColumnType("date");
                entity.Property(e => e.NameOfProject)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.OrderingCompany)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}