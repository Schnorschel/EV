using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EV.Models;
using EV.ViewModels;

namespace EV.Controllers
{
  [ApiController]
  [Route("api/[controller]")]

  public class EVehicleController : ControllerBase
  {
    [HttpGet]
    public ActionResult GetAllEvs()
    {
      var db = new DatabaseContext();
      return Ok(db.EVehicles.OrderBy(ev => ev.Manufacturer).ThenBy(ev => ev.Model));
    }

    // [HttpGet("{id}")]
    // public ActionResult GetEv(int id)
    // {
    //   var db = new DatabaseContext();
    //   var evehicle = db.EVehicles.Include(i => i.EvType).FirstOrDefault(ev => ev.Id == id);
    //   if (evehicle == null)
    //   {
    //     return NotFound();
    //   }
    //   else
    //   {
    //     // create JSON object
    //     var rv = new EVehicleDetails
    //     {
    //       Id = evehicle.Id,
    //       Manufacturer = evehicle.Manufacturer,
    //       Model = evehicle.Model,
    //       BatteryCapacity = evehicle.BatteryCapacity,
    //       EvTypeId = evehicle.EvTypeId,
    //       EvTypeAbbr = evehicle.EvType.EvTypeAbbr
    //     };
    //     return Ok(rv);

    //   }
    // }

    [HttpGet("{id}")]
    public ActionResult GetEv(int id)
    {
      var db = new DatabaseContext();
      var evehicle = db.EVehicles.Include(i => i.EvType).FirstOrDefault(ev => ev.Id == id);
      if (evehicle == null)
      {
        return NotFound();
      }
      else
      {
        // create JSON object
        var rv = new EVehicleDetails
        {
          Id = evehicle.Id,
          Manufacturer = evehicle.Manufacturer,
          Model = evehicle.Model,
          BatteryCapacity = evehicle.BatteryCapacity,
          EvTypeId = evehicle.EvTypeId,
          EvTypeAbbr = evehicle.EvTypes.EvTypeAbbr,
          TypeDetails = new EVehicleDetailsTypeDetails
          {
            EvTypeAbbr = evehicle.EvType.EvTypeAbbr,
            EvTypeLongDescription = evehicle.EvType.EvTypeLongDescription,
            EvTypeShortDescription = evehicle.EvType.EvTypeShortDescription
          }

          // EvTypes = evehicle.EvType.Select(evt => new CreatedEvType
          // {
          //   Id = evt.Id,
          //   EvTypeAbbr = evt.EvTypeAbbr,
          //   EvTypeShortDescription = evt.EvTypeShortDescription,
          //   EvTypeLongDescription = evt.EvTypeLongDescription
          // }).ToList()
        };
        return Ok(rv);

      }
    }

    [HttpPost]
    public ActionResult CreateEVehicle(NewEVehicle evehicle)
    {
      var db = new DatabaseContext();
      var evtype = db.EvTypes.FirstOrDefault(evt => evt.Id == evehicle.EvTypeId);
      if (evtype == null)
      {
        return NotFound();
      }
      else
      {
        var newevehicle = new EVehicle
        {
          EvTypeId = evehicle.EvTypeId,
          Manufacturer = evehicle.Manufacturer,
          Model = evehicle.Model,
          BatteryCapacity = evehicle.BatteryCapacity
        };
        db.EVehicles.Add(newevehicle);
        db.SaveChanges();
        var rv = new CreatedEVehicle
        {
          Id = newevehicle.Id,
          EvTypeId = newevehicle.EvTypeId,
          Manufacturer = newevehicle.Manufacturer,
          Model = newevehicle.Model,
          BatteryCapacity = newevehicle.BatteryCapacity
        };
        return Ok(rv);

      }
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteEVehicle(int id)
    {
      var db = new DatabaseContext();
      var evehicle = db.EVehicles.FirstOrDefault(evehicle => evehicle.Id == id);
      if (evehicle == null)
      {
        return NotFound();
      }
      else
      {
        db.EVehicles.Remove(evehicle);
        db.SaveChanges();
        return Ok();
      }
    }

    [HttpPut("{id}")]
    public ActionResult UpdateEVehicle(EVehicle evehicle)
    {
      var db = new DatabaseContext();
      var existEvehicle = db.EVehicles.FirstOrDefault(ev => ev.Id == evehicle.Id);
      if (existEvehicle == null)
      {
        return NotFound();
      }
      else
      {
        existEvehicle.EvTypeId = evehicle.EvTypeId;
        existEvehicle.Manufacturer = evehicle.Manufacturer;
        existEvehicle.Model = evehicle.Model;
        existEvehicle.BatteryCapacity = evehicle.BatteryCapacity;
        db.SaveChanges();
        return Ok(existEvehicle);
      }
    }
  }
}