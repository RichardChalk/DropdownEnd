using BankAccountTransactionsEnd.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SkysFormsDemo.Data;

public class DataInitializer
{
    private readonly ApplicationDbContext _dbContext;

    public DataInitializer(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void SeedData()
    {
        _dbContext.Database.Migrate();
        SeedAccounts();
    }

    private void SeedAccounts()
    {
        if (_dbContext.Accounts.Any(a => a.AccountNo == "12345")) return;

        _dbContext.Add(new Account
        {
            AccountNo = "12345",
            Balance = 1500
        });
        _dbContext.SaveChanges();
    }
}