using Backend.Model;

namespace Backend.Interface
{
    public interface IPurchase
    {
        ICollection<Purchase> GetAllPurchase();
        Purchase GetPurchaseById(int id);
        void CreatePurchase(Purchase purchase);
        void UpdatePurchase(Purchase purchase);
        void DeletePurchase(int id);
    }
}
