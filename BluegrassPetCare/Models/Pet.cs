using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BluegrassPetCare.Models
{
    public class Pet
    {
        [Key]
        public int PetId { get; set; }

        [Required]
        public string ImagePath { get; set; }

        [Required]
        [StringLength(55, ErrorMessage = "Please shorten the product title to 55 characters")]
        [RegularExpression(@"^[0-9a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "special characters are not  allowed.")]
        public string Name { get; set; }

        [Required]
        public int SpeciesId { get; set; }
        public Species Species { get; set; }

        [Required]
        public int BreedId { get; set; }
        public Breed Breed { get; set; }

        public DateTime Birthday { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public int SexId { get; set; }
        public Sex Sex { get; set; }

        [Required]
        public bool isSpayedOrNeutered{ get; set; }

        public string CurrentMedications { get; set; }

        public string OngoingProblems { get; set; }

    }
}