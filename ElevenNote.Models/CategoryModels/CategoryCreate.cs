using System.ComponentModel.DataAnnotations;

namespace ElevenNote.Models.CategoryModels
{
    public class CategoryCreate
    {
          [Required]
          public string Name { get; set; } = null!;
    }
}