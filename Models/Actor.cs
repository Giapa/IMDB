using System;
using System.ComponentModel.DataAnnotations;
using MvcMovie.Models;
using MvcSeries.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcActor.Models
{
    public class Actor
    {
        public int ActorId { get; set; }
        public string Bio { get; set; }
        public string Profile_pic_path { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [ForeignKey("Id")]
        public Movie Movie {get;set;}
        public int MovieId {get;set;}

        [ForeignKey("Id")]
        public Series Series {get;set;}
        public int SeriesId {get;set;}
    }
}