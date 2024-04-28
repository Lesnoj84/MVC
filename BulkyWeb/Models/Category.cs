using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace BulkyWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required,DisplayName("Category Name"),MaxLength(50,ErrorMessage ="Can not be empty")] //Sets how the parameter will be displayed of Web/Page
        public string?  Name { get; set; }
        [DisplayName ("Display Name"),Range(1,100)] //Sets how the parameter will be displayed of Web/Page
        public int DisplayOrder { get; set; }

    }
}
