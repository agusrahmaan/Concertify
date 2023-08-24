using Backend.Model;

namespace Backend.Interface
{
    public interface IConcert
    {
        ICollection<Concert> GetAllConcert();
        Concert GetConcertById(int id);
        void CreateConcert(Concert concert);
        void UpdateConcert(Concert concert);
        void DeleteConcert(int id);
    }
}
