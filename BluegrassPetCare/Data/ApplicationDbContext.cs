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
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Note> Note { get; set; }

        public DbSet<Pet> Pet { get; set; }

        public DbSet<PetUser> PetUser { get; set; }

        public DbSet<Sex> Sex { get; set; }

        public DbSet<Species> Species { get; set; }

        public DbSet<Breed> Breed { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            modelBuilder.Entity<Note>()
                .Property(b => b.DateAdded)
                .HasDefaultValueSql("GETDATE()");


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

            modelBuilder.Entity<Sex>().HasData(
               new Sex()
               {
                   SexId = 1,
                   Type = "Male"
               },
               new Sex()
               {
                   SexId = 2,
                   Type = "Female"
               }
            );
            modelBuilder.Entity<Species>().HasData(
               new Species()
               {
                   SpeciesId = 1,
                   Type = "Dog"
               },
               new Species()
               {
                   SpeciesId = 2,
                   Type = "Cat"
               },
               new Species()
               {
                   SpeciesId = 3,
                   Type = "Wolf"
               },
               new Species()
               {
                   SpeciesId = 4,
                   Type = "Human"
               },
               new Species()
               {
                   SpeciesId = 5,
                   Type = "Bald Eagle"
               }
            );
            modelBuilder.Entity<Breed>().HasData(
               new Breed()
               {
                   BreedId = 1,
                   BreedName = "Boston Terrier"
               },
               new Breed()
               {
                   BreedId = 2,
                   BreedName = "Rotweiler"
               },
               new Breed()
               {
                   BreedId = 3,
                   BreedName = "Hemmingway"
               },
               new Breed()
               {
                   BreedId = 4,
                   BreedName = "Shitzu"
               }
            );

        }

    }
}