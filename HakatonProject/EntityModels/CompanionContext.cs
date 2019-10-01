using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace HakatonProject.EntityModels
{
    public class CompanionContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Week> Weeks { get; set; }

        public CompanionContext(DbContextOptions<CompanionContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCar>()
                .HasKey(t => new { t.UserId, t.CarId });

            modelBuilder.Entity<UserCar>()
                .HasOne(sc => sc.User)
                .WithOne(s => s.UserCar);

            modelBuilder.Entity<UserCar>()
                .HasOne(sc => sc.Car)
                .WithMany(c => c.UserCar)
                .HasForeignKey(sc => sc.CarId);


            modelBuilder.Entity<Car>()
                .HasOne(p => p.User)
                .WithOne(b => b.Car);


            modelBuilder.Entity<Car>()
                .HasOne(p => p.Week)
                .WithOne(b => b.Car);

            modelBuilder.Entity<CompanionRequest>()
                .HasOne(p => p.Car)
                .WithMany(b => b.CompanionRequest)
                .HasForeignKey(k => k.CarId);

            modelBuilder.Entity<CompanionRequest>()
                .HasOne(p => p.User)
                .WithMany(b => b.CompanionRequest)
                .HasForeignKey(k => k.UserId);
        }


    }
}
