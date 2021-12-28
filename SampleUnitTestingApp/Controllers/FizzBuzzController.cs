using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SampleUnitTestingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FizzBuzzController : ControllerBase
    {
        [HttpGet]
        public string Get(int value)
        {
            string result = string.Empty;
            for(int i =1; i<=value; i++)
            {
                if (i % 3 == 0 && i%5==0)
                    result += $"FizzBuzz ";
                else if (i % 3 == 0)
                    result += $"Fizz ";
                else if (i % 5 == 0)
                    result += $"Buzz ";
                else
                    result += $"{i} ";
            }
            return result;
        }
    }
}
