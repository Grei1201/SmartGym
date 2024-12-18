using System;
using System.ComponentModel.DataAnnotations;

public class GymMachine
    {
        [Key]
        public int IdMachine { get; set; } 

        [StringLength(20)]
        public string NameMachine { get; set; } 

        public DateTime DateBuy { get; set; } 

        public DateTime DateMantence { get; set; } 

        [Range(0, 9999999999)]
        public long Brand { get; set; } 

        [StringLength(20)]
        public string Status { get; set; } 
    }
