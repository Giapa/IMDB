using System;
using System.ComponentModel.DataAnnotations;
using MvcComments.Models;
using System.Collections.Generic;

namespace MvcMovie.Models{
    public class Movie{
        public int Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public string Poster_path { get; set; }
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Rating { get; set; }
        public decimal Budget { get; set; }
        public List<Comments> Comments {get; set;}
    }
}
