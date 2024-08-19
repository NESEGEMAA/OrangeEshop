using System.ComponentModel.DataAnnotations;

namespace OrangeEshop.DAL.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(70)]
        public string? Description { get; set; }
    }
}