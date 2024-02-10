using Egzamin2023.Models;

namespace Egzamin2023.Services
{
    public class NoteService
    {
        private List<NoteViewModel> _notes = new List<NoteViewModel>();
        private IDateProvider _dateProvider;

        public NoteService(IDateProvider dateProvider)
        {
            _dateProvider = dateProvider;
        }
        public void Add(NoteViewModel note)
        {
            _notes.Add(note);
        }
        public IEnumerable<NoteViewModel> GetAll()
        {
            return _notes.Where(
                n => n.DeadLine > _dateProvider.CurrentDate).ToList();
        }
        public NoteViewModel GetById(string Title)
        {
            return _notes.FirstOrDefault(n => n.Title == Title);
        }
    }
}