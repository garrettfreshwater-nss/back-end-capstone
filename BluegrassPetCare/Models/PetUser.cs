using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BluegrassPetCare.Models
{
    public class PetUser
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int PetId { get; set; }
    }
}