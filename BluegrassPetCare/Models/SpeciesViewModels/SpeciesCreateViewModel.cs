using BluegrassPetCare.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bluegrass.Models.SpeciesViewModels
{
    public class SpeciesCreateViewModel
    {
        [Key]
        public int SpeciesId { get; set; }

        [StringLength(255)]
        [Display(Name = "Species Type")]
        public string Type { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        public Pet Pet { get; set; }

        public List<Species> Species { get; set; }

        public IEnumerable<Pet> Pets { get; set; }

    }
}