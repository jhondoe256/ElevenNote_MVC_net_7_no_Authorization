using ElevenNote.Models.NoteModels;
using ElevenNote.Services.NoteServices;
using Microsoft.AspNetCore.Mvc;

namespace ElevenNote.MVC.Controllers
{
    [Route("[controller]")]
    public class Notecontroller : Controller
    {
        private INoteService _noteService;

        public Notecontroller(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _noteService.GetNotes());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            return View(await _noteService.GetNoteById(id));
        }

        [HttpGet]
        [Route("Post")]
        public async Task<IActionResult> Post()
        {
            return View();
        }
        [HttpPost]
        [Route("Post")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Post(NoteCreate model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (await _noteService.CreateNote(model))
                return RedirectToAction(nameof(Index));
            else
                return View(model);
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var note = await _noteService.GetNoteById(id);
            var noteEdit = new NoteEdit
            {
                Id = note.Id,
                Title = note.Title,
                Content = note.Content,
                CategoryId = note.Category.Id
            };
            return View(noteEdit);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, NoteEdit model)
        {
            if(id!=model.Id) return BadRequest("Invlaid Id.");
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (await _noteService.UpdateNote(model))
                return RedirectToAction(nameof(Index));
            else
                return View(model);
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            var note = await _noteService.GetNoteById(id.Value);
            return View(note);
        }

        [HttpPost]
        [Route("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var isSuccessful = await _noteService.DeleteNote(id);
            if (isSuccessful)
                return RedirectToAction(nameof(Index));
            else
                return UnprocessableEntity();
        }
    }
}