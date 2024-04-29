using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required, DisplayName("Product Name"), MaxLength(50, ErrorMessage = "Can not be empty")] //Sets how the parameter will be displayed of Web/Page
        public string? Name { get; set; }
        [DisplayName("Orders Qty"), Range(1, 100)] //Sets how the parameter will be displayed of Web/Page
        public int DisplayOrder { get; set; }

    }
}
