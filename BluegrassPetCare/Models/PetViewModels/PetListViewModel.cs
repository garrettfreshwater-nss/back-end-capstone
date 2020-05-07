using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BluegrassPetCare.Models.PetViewModels
{
    public class PetListViewModel
    {
        public IEnumerable<Pet> Pets { get; set; }
    }
}
