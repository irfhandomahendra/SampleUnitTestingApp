using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleUnitTestingApp.Data;
using SampleUnitTestingApp.Dtos;
using SampleUnitTestingApp.Models;
using System.Threading.Tasks;

namespace SampleUnitTestingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplyController : ControllerBase
    {
        private readonly ICreditCardApplicationRepository _applicationRepository;

        public ApplyController(ICreditCardApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public async Task<ActionResult> Add(NewCreditCardApplicationDetails applicationDetails)
        {
            var creditCardApplication = new CreditCardApplication
            {
                FirstName = applicationDetails.FirstName,
                LastName = applicationDetails.LastName,
                Age = applicationDetails.Age.Value,
                GrossAnnualIncome = applicationDetails.GrossAnnualIncome.Value
            };
            await _applicationRepository.AddAsync(creditCardApplication);
            return Ok(creditCardApplication);
        }
    }
}
