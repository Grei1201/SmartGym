using System;
using System.ComponentModel.DataAnnotations;

    public class Membership
    {
        [Key]
        public int IdMembership { get; set; } 

        [StringLength(20)]
        public string MembershipName { get; set; } 

        public int MambDays { get; set; }

        public bool Active { get; set; } 

        public DateTime PrimDate { get; set; } 
        public decimal Price { get; set; } 
    }
