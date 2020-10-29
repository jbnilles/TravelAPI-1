using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TravelApiClient.Models;

namespace TravelApiClient.Controllers
{
  public class PlacesController : Controller
  {
    
    public IActionResult Index()
    {
      var allPlaces = Place.GetPlaces();
      return View(allPlaces);
    }
    [HttpPost]
    public IActionResult Index(Place place)
    {
      Place.Post(place);
      return RedirectToAction("Index");
    }
    public IActionResult Details(int id)
    {
      var place = Place.GetDetails(id);
      return View(place);
    }
    
    public IActionResult Edit (int id)
    {
      var place = Place.GetDetails(id);
      return View(place.Data);
    }
    [HttpPost]
    public IActionResult Edit (Place place)
    {
      Place.Put(place);  
      return RedirectToAction("Index");
    }

  } 
}