using ElevenNote.Models.NoteModels;

namespace ElevenNote.Services.NoteServices
{
    public interface INoteService
    {
        Task<bool> CreateNote(NoteCreate model);
        Task<bool> UpdateNote(NoteEdit model);
        Task<bool> DeleteNote(int id);
        Task<NoteDetail> GetNoteById(int id);
        Task<List<NoteListItem>> GetNotes();
    }
}