using System;
using System.ComponentModel.DataAnnotations;
using MvcMovie.Models;
using MvcSeries.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcComments.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public string Creator { get; set; }

        [DataType(DataType.Date)]
        public DateTime PubDate { get; set; }
        public string Text { get; set; }

        [ForeignKey("Id")]
        public Movie Movie {get;set;}
        public int MovieId {get;set;}

        [ForeignKey("Id")]
        public Series Series {get;set;}
        public int SeriesId {get;set;}
    }
}