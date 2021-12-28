using System.ComponentModel.DataAnnotations;

namespace SampleUnitTestingApp.Dtos
{
    public class NewCreditCardApplicationDetails
    {
        [Required(ErrorMessage = "Please provide a first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please provide a last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please provide an age in years")]
        [Range(18, int.MaxValue, ErrorMessage = "You must be at least 18 years old")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "Please provide your gross income")]
        public decimal? GrossAnnualIncome { get; set; }

    }
}
