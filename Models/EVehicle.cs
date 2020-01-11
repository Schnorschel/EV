namespace EV.Models
{
  public class EVehicle
  {
    public int Id { get; set; }
    public string Manufacturer { get; set; }
    public string Model { get; set; }
    public double BatteryCapacity { get; set; }

    public int EvTypeId { get; set; }
    public EvType EvType { get; set; }
  }
}