using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;



namespace Assignment9.Models
{
    //class to hold newMovie input from user. All are required fields but the last 3
    //notes is limited to 25 characters

    //this class is the movie class 
    public class Movie
    {
        [Key]
        public int movieID { get; set; }
        [Required]
        public string category { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public int year { get; set; }
        [Required]
        public string director { get; set; }
        [Required]
        public string rating { get; set; }
        [Required]
        public string edited { get; set; }
        public string lent { get; set; }
        [StringLength(25)]
        public string notes { get; set; }

    }
}
