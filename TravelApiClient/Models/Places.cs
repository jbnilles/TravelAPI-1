using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TravelApiClient.Models
{
  public class Place
  {
    // [Required]
    public int PlaceId { get; set; }
    // [Required]
    public double AverageRating { get; set; }
    // [Required]
    public string Landmark { get; set; }
    // [Required]
    public string City { get; set; }
    // [Required]
    public string Country { get; set; }

    
    // [Required]
    //public virtual IEnumerable<Review> Reviews { get; set; }
    public static PagedResponse<List<Place>> GetPlaces()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;
      System.Console.WriteLine(result);
      PagedResponse<List<Place>> jsonResponse = JsonConvert.DeserializeObject<PagedResponse<List<Place>>>(result);
      System.Console.WriteLine(jsonResponse);
      return jsonResponse;
      //List<Place> placeList = JsonConvert.DeserializeObject<List<Place>>(jsonResponse.ToString());
      //return placeList;
    }
    public static Place GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Place place = JsonConvert.DeserializeObject<Place>(jsonResponse.ToString());
      return place;
    }
     public static void Post(Place place)
    {
      string jsonPlace = JsonConvert.SerializeObject(place);
      var apiCallTask = ApiHelper.Post(jsonPlace);
    }
    public static void Put(Place place)
    {
      string jsonPlace = JsonConvert.SerializeObject(place);
      var apiCallTask = ApiHelper.Put(place.PlaceId, jsonPlace);
    }
    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.Delete(id);
    }
  }

}