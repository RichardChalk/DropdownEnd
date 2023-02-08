using BankAccountTransactionsEnd.Data;
using SkysFormsDemo.Data;

namespace BankAccountTransactionsEnd.Services
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _dbContext;

        public AccountService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Account> GetAccounts()
        {
            return _dbContext.Accounts.ToList();
        }

        public Account GetAccount(int accountId)
        {
            return _dbContext.Accounts.First(a => a.Id == accountId);
        }

        public void Update(Account account)
        {
            _dbContext.SaveChanges();
        }
    }
}
