using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BluegrassPetCare.Models
{
    public class Species
    {
        [Key]
        public int SpeciesId { get; set; }

        [StringLength(255)]
        [Display(Name = "Species")]
        public string SpeciesType { get; set; }

        public string UserId { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
    }
}
