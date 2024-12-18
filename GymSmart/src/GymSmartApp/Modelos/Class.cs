using System;
using System.ComponentModel.DataAnnotations;

    public class Class
    {
        [Key]
        public int IdClass { get; set; } 

        [StringLength(20)]
        public string NameClass { get; set; } 

        public DateTime Day { get; set; } 

        public TimeSpan Hour { get; set; } 

        public int IdTrainner { get; set; } 
        public Trainner Trainner { get; set; } 

        public int Space { get; set; } 
    }
