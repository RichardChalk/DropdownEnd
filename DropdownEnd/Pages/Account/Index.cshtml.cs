using BankAccountTransactionsEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankAccountTransactionsEnd.Pages.Account
{
    public class IndexModel : PageModel
    {
        private readonly IAccountService _accountService;

        public IndexModel(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public List<AccountViewModel> Accounts { get; set; }

        public class AccountViewModel
        {
            public int Id { get; set; }
            public string AccountNo { get; set; }
            public decimal Balance { get; set; }
        }

        public void OnGet()
        {
            Accounts = _accountService.GetAccounts()
                .Select(a => new AccountViewModel
                {
                    Id = a.Id,
                    AccountNo = a.AccountNo,
                    Balance = a.Balance
                }).ToList();
        }
    }

}
