using System;
using newEmpty.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using newEmpty.ViewModels;

namespace newEmpty.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>

{
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Professor> Professors => Set<Professor>();
   

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>()
            .HasMany(s => s.Professors)
            .WithMany(p => p.Students);

        modelBuilder.Entity<Professor>()
            .HasMany(p => p.Students)
            .WithMany(s => s.Professors);

        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Student>().HasData(
            new Student()
            {
                StudentId = 1,
                FirstName = "Billy",
                LastName = "kems",
                BirthDate = new DateTime(1990, 12, 12)
            }
        );

        modelBuilder.Entity<Professor>().HasData(
            new Professor()
            {
                ProfessorId = 1,
                FirstName = "Billy",
                LastName = "K1000",
                Matiere = "Math"
            }
        );
    }
}
