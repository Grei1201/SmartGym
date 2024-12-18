using System.ComponentModel.DataAnnotations;

public class Client
    {
        [Key]
        public int IdClient { get; set; } 

        [Required]
        public string Password { get; set; }

        public string Name { get; set; } 
        public string LastName1 { get; set; } 
        public string LastName2 { get; set; } 
        public long Phone { get; set; } 
        public string City { get; set; } 
        public string Direcition { get; set; } 
        public int Age { get; set; } 
    }