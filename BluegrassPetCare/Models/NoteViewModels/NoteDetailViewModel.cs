using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BluegrassPetCare.Models.NoteViewModels
{
    public class NoteDetailViewModel
    {
        public int Id { get; set; }
        public Note Note { get; set; }
        public IFormFile ImageFile { get; set; }

        public List<SelectListItem> PetsTypeOptions { get; set; }

    }
}
