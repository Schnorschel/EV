using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EV.Models;
using EV.ViewModels;

namespace EV.Controllers
{
  [ApiController]
  [Route("api/[controller]")]

  public class EvTypeController : ControllerBase
  {
    [HttpGet]
    public ActionResult GetAllEvTypes()
    {
      var db = new DatabaseContext();
      return Ok(db.EvTypes.OrderBy(ev => ev.Id));
    }

    [HttpGet("{id}")]
    public ActionResult GetEvType(int id)
    {
      var db = new DatabaseContext();
      var evtype = db.EvTypes.FirstOrDefault(ev => ev.Id == id);
      if (evtype == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(evtype);
      }
    }

    [HttpPost]
    public ActionResult CreateEvType(NewEvType evtype)
    {
      var db = new DatabaseContext();
      var prevEvType = db.EvTypes.FirstOrDefault(et => et.EvTypeAbbr.ToLower() == evtype.EvTypeAbbr.ToLower());
      if (prevEvType != null)
      {
        var everror = new EvError
        {
          Error = "A record with EvTypeAbbr: '" + evtype.EvTypeAbbr + "' already exists"
        };
        return Conflict(everror);
      }
      else
      {
        var newevtype = new EvType
        {
          EvTypeAbbr = evtype.EvTypeAbbr.ToUpper().Trim(),
          EvTypeShortDescription = evtype.EvTypeShortDescription,
          EvTypeLongDescription = evtype.EvTypeLongDescription
        };
        db.EvTypes.Add(newevtype);
        db.SaveChanges();
        var rv = new CreatedEvType
        {
          Id = newevtype.Id,
          EvTypeAbbr = newevtype.EvTypeAbbr,
          EvTypeShortDescription = newevtype.EvTypeShortDescription,
          EvTypeLongDescription = newevtype.EvTypeLongDescription
        };
        return Ok(rv);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult DeleteEvType(int id)
    {
      var db = new DatabaseContext();
      var evtype = db.EvTypes.FirstOrDefault(ev => ev.Id == id);
      if (evtype == null)
      {
        return NotFound();
      }
      else
      {
        db.EvTypes.Remove(evtype);
        db.SaveChanges();
        return Ok();
      }
    }

    [HttpPut("{id}")]
    public ActionResult UpdateEvType(EvType evtype)
    {
      var db = new DatabaseContext();
      var existEvtype = db.EvTypes.FirstOrDefault(ev => ev.Id == evtype.Id);
      if (existEvtype == null)
      {
        return NotFound();
      }
      // else if (db.EvTypes.FirstOrDefault(ev => ev.EvTypeAbbr.ToLower().Trim() == evtype.EvTypeAbbr.ToLower().Trim()) != null) {
      // }
      else
      {
        existEvtype.EvTypeAbbr = evtype.EvTypeAbbr;
        existEvtype.EvTypeShortDescription = evtype.EvTypeShortDescription;
        existEvtype.EvTypeLongDescription = evtype.EvTypeLongDescription;
        db.SaveChanges();
        return Ok(existEvtype);
      }
    }
  }
}