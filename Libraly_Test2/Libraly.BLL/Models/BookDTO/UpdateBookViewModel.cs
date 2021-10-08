﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Libraly.BLL.Models.BookDTO
{
    public class UpdateBookViewModel
    {
        [Required (ErrorMessage = "Need ID")]
        public  long Id { get; set; }
        public DateTime YearBook { get; set; }
        [Range(1,1000,ErrorMessage = "So a lot of count")]
        public int Count { get; set; }
        [Required (ErrorMessage = "Name is null!")]
        public string NameOfBook { get; set; }
        [Required (ErrorMessage = "Author is null!")]
        public string AuthorOfBook { get; set; }
        [Required (ErrorMessage = "Description can't to be null!")]
        public string LittleDescription { get; set; }
        [Required (ErrorMessage = "Genres can't to be null")]
        public string Genres { get; set; }
        public string LongDescription { get; set; }
        public string PhotoUrl { get; set; }
        
    }
}