using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBook.Models;

public class Product
{
    [Key]
    public int Id { get; set; }
    
    [Required, DisplayName("Title Name"), MaxLength(50, ErrorMessage = "Can not be empty")] //Sets how the parameter will be displayed of Web/Page
    public string? Title { get; set; }
    
    [Required]
    public string? Description { get; set; }
    
    [Required]
    public string? ISBN { get; set; }
    
    [Required]
    public string? Author { get; set; }

    [Required, Display(Name = "List Price"), Range(1, 100)]
    public double ListPrice { get; set; }

    [Required,Display(Name ="Price for 1-50"),Range(1,100)]
    public double Price { get; set; }

    [Required, Display(Name = "Price for 50+"), Range(1, 100)]
    public double Price50 { get; set; }

    [Required, Display(Name = "Price for 100+"), Range(1, 100)]
    public double Price100 { get; set; }
}
