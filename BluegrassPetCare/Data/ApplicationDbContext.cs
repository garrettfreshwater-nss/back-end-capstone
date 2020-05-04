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
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            modelBuilder.Entity<Note>()
                .Property(b => b.DateAdded)
                .HasDefaultValueSql("GETDATE()");

            // Restrict deletion of related product when OrderProducts entry is removed
            //modelBuilder.Entity<Pet>()
            //    .HasMany(o => o.UserId)
            //    .WithOne(l => l.User)
            //    .OnDelete(DeleteBehavior.Restrict);

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
                   Name = "Lucy",
                   Breed = "",
                   Color = "",
                   ImagePath = ""
               }
            );
            modelBuilder.Entity<Sex>().HasData(
               new Sex()
               {
                   Id = 1,
                   Type = "Male"
               },
               {
                Id = 2,
                   Type = "Female"
               }
            );


        }

    }
}