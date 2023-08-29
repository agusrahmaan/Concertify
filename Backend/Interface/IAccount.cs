using Backend.Model;

namespace Backend.Interface
{
    public interface IAccount
    {
        ICollection<Account> GetAllAccounts();
        Account GetAccountByName(string name);
        Account GetAccountByEmail(string email);
        Account GetAccountByPhone(string phone);
        void Register(Account account);
    }
}
