using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BluegrassPetCare.Models
{
    public class Breed
    {
        [Key]
        public int BreedId { get; set; }
       
        [StringLength(255)]
        [Display(Name = "Breed")]
        public string BreedName { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
    }
}
