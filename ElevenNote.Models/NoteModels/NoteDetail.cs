using ElevenNote.Models.CategoryModels;

namespace ElevenNote.Models.NoteModels
{
    public class NoteDetail
    {

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public CategoryListItem Category { get; set; } = null!;
    }
}