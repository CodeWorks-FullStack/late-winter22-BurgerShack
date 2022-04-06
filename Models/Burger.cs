using System.ComponentModel.DataAnnotations;

namespace BurgerShack.Models
{
  public class Burger
  {
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [MaxLength(200)]
    public string Description { get; set; } 
    
    [Range(.01, double.MaxValue)]
    public double Price { get; set; }
  }
}