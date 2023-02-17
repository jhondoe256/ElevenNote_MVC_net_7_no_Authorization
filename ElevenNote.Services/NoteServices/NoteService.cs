using AutoMapper;
using ElevenNote.Data.Context;
using ElevenNote.Data.Entities;
using ElevenNote.Models.NoteModels;
using Microsoft.EntityFrameworkCore;

namespace ElevenNote.Services.NoteServices
{
    public class NoteService : INoteService
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;

        public NoteService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateNote(NoteCreate model)
        {
            var note = _mapper.Map<Note>(model);
            await _context.Notes.AddAsync(note);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteNote(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note is null) return false;
            else
            {
                _context.Notes.Remove(note);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<NoteDetail> GetNoteById(int id)
        {
            var note = await _context.Notes.Include(n => n.Category).FirstOrDefaultAsync(x => x.Id == id);
            if (note is null) return new NoteDetail();

            return _mapper.Map<NoteDetail>(note);
        }

        public async Task<List<NoteListItem>> GetNotes()
        {
            var notes = await _context.Notes.Include(n => n.Category).ToListAsync();
            return _mapper.Map<List<NoteListItem>>(notes);
        }

        public async Task<bool> UpdateNote(NoteEdit model)
        {
            var note = await _context.Notes.FindAsync(model.Id);
            if (note is null) return false;
            else
            {
                note.CategoryId = model.CategoryId;
                note.Title = model.Title;
                note.Content = model.Content;

                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}