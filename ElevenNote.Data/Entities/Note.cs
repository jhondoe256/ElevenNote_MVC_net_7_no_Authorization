using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElevenNote.Data.Entities
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;

        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; } = null!;
    }
}