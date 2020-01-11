using System.Collections.Generic;

namespace EV.ViewModels
{

  public class EVehicleDetailsTypeDetails
  {
    public int Id { get; set; }
    public string EvTypeAbbr { get; set; }
    public string EvTypeShortDescription { get; set; }
    public string EvTypeLongDescription { get; set; }
  }

  public class EVehicleDetails
  {
    public int Id { get; set; }
    public string Manufacturer { get; set; }
    public string Model { get; set; }
    public double BatteryCapacity { get; set; }

    public int EvTypeId { get; set; }
    public string EvTypeAbbr { get; set; }

    public EVehicleDetailsTypeDetails TypeDetails { get; set; }



    // public List<CreatedEvType> EvTypes { get; set; } =
    //   new List<CreatedEvType>();
  }
}