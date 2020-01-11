using System.ComponentModel.DataAnnotations;

namespace EV.ViewModels
{
  public class NewEvType
  {
    [Required]
    public string EvTypeAbbr { get; set; }
    public string EvTypeShortDescription { get; set; }
    public string EvTypeLongDescription { get; set; }
  }
}