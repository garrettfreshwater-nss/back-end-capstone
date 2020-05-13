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

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public IFormFile ImageFile { get; set; }
        public string ImagePath { get; set; }

        public List<SelectListItem> SpeciesTypeOptions { get; set; }
        public Species Species { get; set; }
        public int SpeciesId { get; set; }

        public List<SelectListItem> BreedTypeOptions { get; set; }
        public Breed Breed { get; set; }
        public int BreedId { get; set; }

        public List<SelectListItem> SexTypeOptions { get; set; }
        public Sex Sex { get; set; }
        public int SexId { get; set; }

        public List<SelectListItem> NoteTypeOptions { get; set; }  // get notes to partial render on detail view
        public Note Note { get; set; }
        public int NoteId { get; set; }

    }
}