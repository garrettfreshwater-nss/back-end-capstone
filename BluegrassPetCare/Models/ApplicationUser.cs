using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BluegrassPetCare.Models
{
    public class ApplicationUser : IdentityUser
    {
        // You can Add profile data for application users by adding properties to the ApplicationUser class
        public ApplicationUser()
        {
            IsVeterinarian = false;
        }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public bool IsVeterinarian { get; set; }
        public string VeterinarianEmail { get; set; }
        public string VeterinarianName { get; set; }
        public string VeterinarianPhone { get; set; }
        
        public bool IsAdmin { get; set; }

        [AllowNull]
        public string ImagePath { get; set; }


        public virtual ICollection<Pet> Pets { get; set; }
    }
}
