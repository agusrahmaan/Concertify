using Backend.Data;
using Backend.Interface;
using Backend.Model;

namespace Backend.Service
{
    public class ConcertService : IConcert
    {
        private readonly ConcertifyContext _context;
        public ConcertService(ConcertifyContext context)
        {
            _context = context;
        }
        public void CreateConcert(Concert concert)
        {
            _context.Concerts.Add(concert);
            _context.SaveChanges();
        }

        public void DeleteConcert(int id)
        {
            _context.Concerts.Remove(GetConcertById(id));
            _context.SaveChanges();
        }

        public ICollection<Concert> GetAllConcert()
        {
            return _context.Concerts.ToList();
        }

        public Concert GetConcertById(int id)
        {
            return _context.Concerts.Where(c => c.Id == id).FirstOrDefault()!;
        }

        public void UpdateConcert(Concert concert)
        {
            _context.Concerts.Update(concert);
            _context.SaveChanges();
        }
    }
}
