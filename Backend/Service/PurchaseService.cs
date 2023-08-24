using Backend.Data;
using Backend.Interface;
using Backend.Model;

namespace Backend.Service
{
    public class PurchaseService : IPurchase
    {
        private readonly ConcertifyContext _context;
        public PurchaseService(ConcertifyContext context)
        {
            _context = context;
        }

        public void CreatePurchase(Purchase purchase)
        {
            _context.Purchases.Add(purchase);
            _context.SaveChanges();
        }

        public void DeletePurchase(int id)
        {
            _context.Purchases.Remove(GetPurchaseById(id));
            _context.SaveChanges();
        }

        public ICollection<Purchase> GetAllPurchase()
        {
            return _context.Purchases.ToList();
        }

        public Purchase GetPurchaseById(int id)
        {
            return _context.Purchases.Where(p => p.Id == id).FirstOrDefault()!;
        }

        public void UpdatePurchase(Purchase purchase)
        {
            _context.Purchases.Update(purchase);
            _context.SaveChanges();
        }
    }
}
