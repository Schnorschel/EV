using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EV.Models
{
  public class EvType
  {
    public int Id { get; set; }
    // public int EVehicleId { get; set; }
    [Required]
    public string EvTypeAbbr { get; set; }
    public string EvTypeShortDescription { get; set; }
    public string EvTypeLongDescription { get; set; }

    public List<EVehicle> EVehicles { get; set; } =
      new List<EVehicle>();

  }
}