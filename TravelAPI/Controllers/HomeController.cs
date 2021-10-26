using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAPI.Models;
using System.Linq;
using System;
// using Microsoft.AspNetCore.Mvc;

namespace TravelAPI.Controllers
{
    public class HomeController : Controller
    {
    private readonly TravelAPIContext _db;

    public HomeController(TravelAPIContext db)
    {
      _db = db;
    }
      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }

      // Attempt to add index
      [HttpGet("/Sort")]
      public ViewResult Sort(string sortOrder, string searchString)
      {
        ViewBag.RatingSortParm = String.IsNullOrEmpty(sortOrder) ? "rating_desc" : "";
        ViewBag.CountrySortParm = sortOrder == "Country" ? "country_desc" : "Country";
        var destinations = from s in _db.Destinations
                      select s;
        if (!String.IsNullOrEmpty(searchString))
        {
          destinations = destinations.Where(s => s.Country.Contains(searchString)
          || s.City.Contains(searchString));
        }
        switch (sortOrder)
        {
          case "rating_desc":
            destinations = destinations.OrderByDescending(s => s.Rating);
            break;
          case "Country":
            destinations = destinations.OrderBy(s => s.Country);
            break;
          case "country_desc":
            destinations = destinations.OrderByDescending(s => s.Country);
            break;
          default:
            destinations = destinations.OrderBy(s => s.Rating);
            break;
          }

        return View(destinations.ToList());
      }

    }
}