using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAPI.Models;
using System.Linq;

namespace TravelAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DestinationsController : ControllerBase
  {
    private readonly TravelAPIContext _db;

    public DestinationsController(TravelAPIContext db)
    {
      _db = db;
    }

    // GET: api/Destinations
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Destination>>> Get(string username, string country, string city, int rating, string review)
    {
      var query = _db.Destinations.AsQueryable();
      if (username != null)
      {
        query = query.Where(entry => entry.Username == username);
      }
      if (country != null)
      {
        query = query.Where(entry => entry.Country == country);
      }
      if (city != null)
      {
        query = query.Where(entry => entry.City == city);
      } 
      if (rating != null)
      {
        query = query.Where(entry => entry.Rating == rating);
      } 
      if (review != null)
      {
        query = query.Where(entry => entry.Review == review);
      } 
      return await query.ToListAsync();
    }

    // GET: api/Destinations/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Destination>> GetDestination(int id)
    {
        var Destination = await _db.Destinations.FindAsync(id);

        if (Destination == null)
        {
            return NotFound();
        }

    return Destination;
    }

    // POST api/Destinations
    [HttpPost]
    public async Task<ActionResult<Destination>> Post(Destination Destination)
    {
      _db.Destinations.Add(Destination);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetDestination), new { id = Destination.DestinationId }, Destination);
    }

    // PUT: api/Destinations/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Destination Destination)
    {
      if (id != Destination.DestinationId)
      {
        return BadRequest();
      }

      _db.Entry(Destination).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!DestinationExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // DELETE: api/Destinations/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDestination(int id)
    {
      var Destination = await _db.Destinations.FindAsync(id);
      if (Destination == null)
      {
        return NotFound();
      }

      _db.Destinations.Remove(Destination);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    private bool DestinationExists(int id)
    {
      return _db.Destinations.Any(e => e.DestinationId == id);
    }
  }
}


    // public string Username { get; set; }

    // public string Country { get; set; }

    // public string City { get; set; }

    // public int Rating { get; set; }
    
    // public string Review { get; set; }