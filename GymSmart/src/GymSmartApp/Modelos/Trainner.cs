using System.ComponentModel.DataAnnotations;

public class Trainner
    {
        [Key]
        public int IdTrainner { get; set; } 

        [Required]
        [StringLength(20)]
        public string Name { get; set; } 

        [StringLength(20)]
        public string LastName1 { get; set; } 

        [StringLength(20)]
        public string LastName2 { get; set; } 

        [Required]
        public string Password { get; set; } 

        [Range(1000000000, 9999999999)]
        public long Phone { get; set; } 

        [StringLength(20)]
        public string City { get; set; }

        [StringLength(200)]
        public string Direcition { get; set; } 

        public int IdLocal { get; set; } 
        public Local Local { get; set; } 
}
