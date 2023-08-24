using Backend.Data;
using Backend.Interface;
using Backend.Model;

namespace Backend.Service
{
    public class AccountService : IAccount
    {
        private readonly ConcertifyContext _context;

        public AccountService(ConcertifyContext context)
        {
            _context = context;
        }
        public Account GetAccountByEmail(string email)
        {
            return _context.Accounts.Where(x => x.Email == email).FirstOrDefault();
        }

        public Account GetAccountByName(string name)
        {
            return _context.Accounts.Where(x => x.Name == name).FirstOrDefault();
        }

        public Account GetAccountByPhone(string phone)
        {
            return _context.Accounts.Where(x => x.Phone == phone).FirstOrDefault();
        }

        public Account GetAccountByUsername(string username)
        {
            return _context.Accounts.Where(x => x.Username == username).FirstOrDefault();
        }

        public ICollection<Account> GetAllAccounts()
        {
            return _context.Accounts.ToList();
        }

        public void Register(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }
    }
}
