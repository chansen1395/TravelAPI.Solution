using System.ComponentModel.DataAnnotations;


namespace TravelAPI.Models
{
  public class Destination
  {
    public int DestinationId { get; set; }

    [Required]
    [StringLength(20)]
    public string Username { get; set; }

    [Required]
    [StringLength(50)]
    public string Country { get; set; }

    [Required]
    [StringLength(50)]
    public string City { get; set; }

    [Required]
    [Range(1, 5, ErrorMessage = "Please enter a rating between 1 - 5")]
    public int Rating { get; set; }
    
    [Required]
    [StringLength(500)]
    public string Review { get; set; }

  }
  
}

// Author/username
// country
// city
// rating
// review
// date of review - optional


// look up random destination