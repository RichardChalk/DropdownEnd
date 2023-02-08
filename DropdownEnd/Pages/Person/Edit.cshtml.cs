using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using SkysFormsDemo.Services;

namespace SkysFormsDemo.Pages.Person
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IPersonService _personService;

        public EditModel(IPersonService personService)
        {
            _personService = personService;
        }

        [MaxLength(100)][Required] public string Name { get; set; }
        [StringLength(100)] public string StreetAddress { get; set; }
        [StringLength(10)] public string PostalCode { get; set; }
        [StringLength(2)] public string CountryCode { get; set; }
        [Range(0, 100000, ErrorMessage = "Skriv ett tal mellan 0 och 100000")]
        public decimal Salary { get; set; }
        [Range(0, 100)] public int Age { get; set; }
        [StringLength(50)][Required] public string City { get; set; }
        [StringLength(150)][EmailAddress] public string Email { get; set; }

        public void OnGet(int personId)
        {
            var personDb = _personService.GetPerson(personId);
            Name = personDb.Name;
            Age = personDb.Age;
            City = personDb.City;
            CountryCode = personDb.CountryCode;
            Email = personDb.Email;
            PostalCode = personDb.PostalCode;
            Salary = personDb.Salary;
            StreetAddress = personDb.StreetAddress;
        }
        public IActionResult OnPost(int personId)
        {
            if (ModelState.IsValid)
            {
                var personDb = _personService.GetPerson(personId);
                personDb.Name = Name;
                personDb.Age = Age;
                personDb.City = City;
                personDb.CountryCode = CountryCode;
                personDb.Email = Email;
                personDb.PostalCode = PostalCode;
                Salary = personDb.Salary;
                StreetAddress = personDb.StreetAddress;

                _personService.Update(personDb);

                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
