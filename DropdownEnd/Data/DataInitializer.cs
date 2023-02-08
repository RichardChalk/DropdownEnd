using BankAccountTransactionsEnd.Data;
using DropdownEnd.Data;
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
        SeedCountries();
    }

    private void SeedCountries()
    {
        AddCountryIfDoesntExist("FI", "Finland");
        AddCountryIfDoesntExist("DK", "Denmark");
        AddCountryIfDoesntExist("NO", "Norway");
        AddCountryIfDoesntExist("SE", "Sweden");
    }
    private void AddCountryIfDoesntExist(string code, string name)
    {
        if (_dbContext.Countries.Any(c => c.CountryCode == code)) return;
        _dbContext.Countries.Add(new Country { 
            CountryCode= code,
            CountryName= name
        });
        _dbContext.SaveChanges();
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