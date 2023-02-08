using System.ComponentModel.DataAnnotations;

namespace DropdownEnd.Data
{
    public class Country
    {
        public int Id { get; set; }
        [MaxLength(2)] public string CountryCode { get; set; }
        [MaxLength(50)] public string CountryName { get; set; }
    }
}
