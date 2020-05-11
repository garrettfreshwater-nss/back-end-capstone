using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BluegrassPetCare.Models
{
    public class Pet
    {
        [Key]
        public int PetId { get; set; }

        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

        public string ImagePath { get; set; }


        [StringLength(55, ErrorMessage = "Please shorten the product title to 55 characters")]
        [RegularExpression(@"^[0-9a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "special characters are not  allowed.")]
        public string Name { get; set; }

        public string Color { get; set; }

        [Required(ErrorMessage = "Species is required")]
        [Display(Name = "Species Type")]
        public int SpeciesId { get; set; }
        public Species Species { get; set; }



        [Required(ErrorMessage = "Breed is required")]
        [Display(Name = "Breed Name")]
        public int BreedId { get; set; }
        public Breed Breed { get; set; }


        [Required(ErrorMessage = "Sex is required")]
        [Display(Name = "Sex Type")]
        public int SexId { get; set; }
        public Sex Sex { get; set; }


        public bool IsSpayedOrNeutered { get; set; }

        public DateTime Birthday { get; set; }

        [StringLength(255, ErrorMessage = "The Description must be less than 255 characters.")]
        public string CurrentMedications { get; set; }

        [StringLength(255, ErrorMessage = "The Description must be less than 255 characters.")]
        public string OngoingProblems { get; set; }

        public Pet()
        {
            IsSpayedOrNeutered = false;
        }

    }
}