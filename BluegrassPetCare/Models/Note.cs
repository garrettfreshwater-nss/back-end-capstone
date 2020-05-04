﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BluegrassPetCare.Models
{
    public class Note
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime DateAdded { get; set; }

        public string UploadPath { get; set; }

        public int PetId { get; set; }

        public int UserId { get; set; }


    }
}
