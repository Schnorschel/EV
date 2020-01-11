namespace EV.ViewModels
{
  public class CreatedEVehicle
  {
    public int Id { get; set; }
    public int EvTypeId { get; set; }
    public string EvTypeAbbr { get; set; }
    public string Manufacturer { get; set; }
    public string Model { get; set; }
    public double BatteryCapacity { get; set; }
  }
}