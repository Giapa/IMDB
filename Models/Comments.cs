using System;
using System.ComponentModel.DataAnnotations;

namespace MvcComments.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public string Creator { get; set; }

        [DataType(DataType.Date)]
        public DateTime PubDate { get; set; }
        public string Text { get; set; }
    }
}