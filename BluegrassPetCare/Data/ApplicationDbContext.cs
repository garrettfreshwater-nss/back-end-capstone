using BluegrassPetCare.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BluegrassPetCare.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<Note> Note { get; set; }

        public DbSet<Pet> Pet { get; set; }

        public DbSet<PetUser> PetUser { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ApplicationUser user = new ApplicationUser
            {
                FirstName = "Admina",
                LastName = "Straytor",
                UserName = "admin@admin.com",
                IsAdmin = true,
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "00000000-ffff-ffff-ffff-ffffffffffff"
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            modelBuilder.Entity<Pet>().HasData(
               new Pet()
               {
                   Id = 1,
                   Name = "Lucy"
               },
               new Pet()
               {
                   Id = 2,
                   Name = "Coco"
               },
               new Pet()
               {
                   Id = 3,
                   Name = "Tuna"
               },
               new Pet()
               {
                   Id = 4,
                   Name = "Francis"
               },
               new Pet()
               {
                   Id = 5,
                   Name = "Fido"
               },
               new Pet()
               {
                   Id = 6,
                   Name = "Clifford"
               },
               new Pet()
               {
                   Id = 6,
                   Name = "Bernard"
               }
           );

            modelBuilder.Entity<Note>().HasData(
               new Note()
               {
                   Id = 1,
                   Title = "Dog Scratching Leg"
               },
               new Note()
               {
                   Id = 2,
                   Title = "Residential Program"
               },
               new Note()
               {
                   Id = 3,
                   Title = "Travel Program"
               }
           );

            modelBuilder.Entity<PetUser>().HasData(
               new PetUser()
               {
                   Id = 1,
                   PetId = 3,
                   UserId = 2
               },
                new PetUser()
                {
                    Id = 1,
                    PetId = 3,
                    UserId = 2
                },
                new PetUser()
                {
                    Id = 1,
                    PetId = 3,
                    UserId = 2
                },
                 new PetUser()
                 {
                     Id = 1,
                     PetId = 3,
                     UserId = 2
                 },
                  new PetUser()
                  {
                      Id = 1,
                      PetId = 3,
                      UserId = 2
                  },
           );

        }

    }
}