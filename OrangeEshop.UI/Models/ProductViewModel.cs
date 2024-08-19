using OrangeEshop.UI.Models;
using System.ComponentModel.DataAnnotations;

public class ProductViewModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Please enter a valid price with up to two decimal places.")]
    public float Price { get; set; }

    [Required()]
    public int CategoryId { get; set; }

    public CategoryViewModel? Category { get; set; }

    public IEnumerable<CategoryViewModel>? Categories { get; set; }
}
