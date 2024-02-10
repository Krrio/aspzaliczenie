using Egzamin2023.Models;
using Egzamin2023.Services;
using Microsoft.AspNetCore.Mvc;

namespace Egzamin2023.Controllers
{
    public class ExamController : Controller
    {
        private List<NoteViewModel> _notes = new List<NoteViewModel>();
        private NoteService _noteService;

        public ExamController(NoteService noteService)
        {
            _noteService = noteService;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NoteViewModel note)
        {
            if (ModelState.IsValid)
            {
                if (note.DeadLine <= DateTime.Now.AddHours(1))
                {
                    ModelState.AddModelError("DeadLine", "Czas ważności musi być o godzinę późniejszy od bieżącego czasu!");
                    return View(note);
                }
                // Add note to database
                _noteService.Add(note);
                return RedirectToAction("Index");

            }
            return View(note);
        }
        public IActionResult Index()
        {
            var validNotes = _noteService.GetAll();
            return View(validNotes);
        }
        public IActionResult Details(string title)
        {
            var note = _noteService.GetById(title);
            if (note == null)
            {
                return NotFound();
            }
            return View(note);
        }
    }
}
