using System.ComponentModel.DataAnnotations;
using BankAccountTransactionsEnd.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using SkysFormsDemo.Data;
using SkysFormsDemo.Services;

namespace SkysFormsDemo.Pages.Person
{
    [BindProperties]
    public class NewModel : PageModel
    {
        private readonly IPersonService _personService;

        public NewModel(IPersonService personService)
        {
            _personService = personService;
        }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [StringLength(100)]
        public string StreetAddress { get; set; }

        [StringLength(10)]
        public string PostalCode { get; set; }

        //[StringLength(2)]
        //public string CountryCode { get; set; }

        [Range(0, 100000, ErrorMessage = "Skriv ett tal mellan 0 och 100000")]
        public decimal Salary { get; set; }

        [Range(0, 100)]
        public int Age { get; set; }

        [StringLength(50)]
        [Required]
        public string City { get; set; }

        [StringLength(150)]
        [EmailAddress]
        public string Email { get; set; }

        [Range(1,4, ErrorMessage = "Please choose a valid country!")]
        public int CountryId { get; set; }
        public List<SelectListItem> Countries { get; set; }

        public void OnGet()
        {
            FillCountryList();
        }

        private void FillCountryList()
        {
            Countries = _personService.GetCountries().Select(c=> new SelectListItem
            {
                Text = c.CountryName, 
                Value = c.Id.ToString()
            }).ToList();

            // Lägg till Default val
            Countries.Insert(0, new SelectListItem
            {
                Text = "Choose a country",
                Value = "0"
            });
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var person = new Data.Person
                {
                    Age = Age,
                    StreetAddress = StreetAddress,
                    Email = Email,
                    City = City,
                    Salary = Salary,
                    Name = Name,
                    PostalCode = PostalCode,
                    Country = _personService.GetCountries().First(c=>c.Id == CountryId),
                };

                _personService.SaveNew(person);
                return RedirectToPage("Index");
            }

            FillCountryList();
            return Page();
        }
    }
}
