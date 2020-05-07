using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BluegrassPetCare.Models
{
    public class PetUser
    {
        [Key]
        public int PetUserId { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int PetId { get; set; }
        public Pet Pet { get; set; }
    }
}