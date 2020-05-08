using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BluegrassPetCare.Models.PetViewModels
{
    public class PetListViewModel
    {
        public int Id { get; set; }
        public Pet Pet { get; set; }
        public IEnumerable<Pet> Pets { get; set; }
    }
}
