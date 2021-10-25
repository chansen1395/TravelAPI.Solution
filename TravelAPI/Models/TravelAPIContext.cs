using Microsoft.EntityFrameworkCore;

namespace TravelAPI.Models
{
    public class TravelAPIContext : DbContext
    {
      public TravelAPIContext(DbContextOptions<TravelAPIContext> options)
          : base(options)
      {
      }

      public DbSet<Destination> Destinations { get; set; }

      protected override void OnModelCreating(ModelBuilder builder)
      {
        builder.Entity<Destination>()
        .HasData
        (
          new Destination { DestinationId = 1, Username = "Matilda", Country = "Spain", City = "Barcelona", Rating = 4, Review = "Let me go" },
          new Destination { DestinationId = 2, Username = "Rexie", Country = "Japan", City = "San Diego", Rating = 5, Review = "It's great" },
          new Destination { DestinationId = 3, Username = "Matilda", Country = "Japan", City = "Tokyo", Rating = 5, Review = "Totemo iidesu" },
          new Destination { DestinationId = 4, Username = "Pip", Country = "Argentina", City = "Buenos Aires", Rating = 4, Review = "Hyperinflation made me a millionaire" },
          new Destination { DestinationId = 5, Username = "Pip", Country = "Poland", City = "Krakow", Rating = 3, Review = "Best accordian music ever" }
        );
      }
    }
}


// public string Username { get; set; }

// public string Country { get; set; }

// public string City { get; set; }

// public int Rating { get; set; }

// public string Review { get; set; }