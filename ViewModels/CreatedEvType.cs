using System.ComponentModel.DataAnnotations;
namespace EV.ViewModels
{
  public class CreatedEvType
  {
    public int Id { get; set; }
    public string EvTypeAbbr { get; set; }
    public string EvTypeShortDescription { get; set; }
    public string EvTypeLongDescription { get; set; }
  }
}