using BluegrassPetCare.Models;
using BluegrassPetCare.Data;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using Microsoft.AspNetCore.Http;

namespace BluegrassPetCare.Models.PetViewModels
{
    public class PetDetailViewModel
    {
        public Pet Pet { get; set; }
        //public List<SelectListItem> ProductTypes { get; set; }
        public IFormFile ImageFile { get; set; }
        public Species Species { get; set; }
        public Breed Breed { get; set; }
        public Sex Sex { get; set; }
    }
}