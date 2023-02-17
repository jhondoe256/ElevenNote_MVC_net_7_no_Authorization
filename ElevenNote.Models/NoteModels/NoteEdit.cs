using System.ComponentModel.DataAnnotations;

namespace ElevenNote.Models.NoteModels
{
    public class NoteEdit
    {

        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public string Content { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }
    }
}