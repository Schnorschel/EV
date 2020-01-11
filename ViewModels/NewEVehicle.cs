using System.ComponentModel.DataAnnotations;

namespace EV.Models
{
  public class NewEVehicle
  {
    public string Manufacturer { get; set; }
    public string Model { get; set; }
    public double BatteryCapacity { get; set; }
    public int EvTypeId { get; set; }
  }
}