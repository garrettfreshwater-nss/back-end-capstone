using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BluegrassPetCare.Models
{
    public class Note
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateAdded { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; 

        public string UploadPath { get; set; }

        public int PetId { get; set; }

        public int UserId { get; set; }

    }
}
