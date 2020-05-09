using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BluegrassPetCare.Models
{
    public class Sex
    {
        [Key]
        public int SexId { get; set; }

        
        [StringLength(255)]
        [Display(Name = "Sex")]
        public string SexType { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
    }
}
