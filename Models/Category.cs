using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_Demo.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]  // This is set to display the name of string Name as Category Name at the time of launch or in view
        public string Name { get; set; }
        [DisplayName("Display Order")] //Can also do this inside label. This is an other way that's it. <label>Display Name</label>
        [Range(1,100, ErrorMessage = "Display Order must be between 1 - 100")]
        public int DisplayOrder { get; set; }

    } 
}
