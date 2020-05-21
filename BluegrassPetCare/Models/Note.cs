using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BluegrassPetCare.Models
{
    public class Note
    {
        [Key]
        public int NoteId { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateAdded { get; set; }

     
        [StringLength(55, ErrorMessage = "The Title must be less than 55 characters.")]
        public string Title { get; set; }

    
        [StringLength(255, ErrorMessage = "The Description must be less than 255 characters.")]
        public string Description { get; set; }

        public string UploadPath { get; set; }

        public int PetId { get; set; }
        public Pet Pet { get; set; }
    }
}
