using Microsoft.AspNetCore.Mvc;
using SampleUnitTestingApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CreditCards.Test.Controllers
{
    public class ValuesControllerShould
    {
        [Fact]
        public void ReturnValue()
        {
            var sut = new ValuesController();
            string[] result = sut.Get().ToArray();

            Assert.Equal(2, result.Length);
            Assert.Equal("value1", result[0]);
            Assert.Equal("value2", result[1]);
        }

        [Fact]
        public void ReturnBadRequest()
        {
            var sut = new ValuesController();
            ActionResult result = sut.Get(0);
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Invalid request for id 0", badRequestResult.Value);
        }

        [Fact]
        public void PostOk()
        {
            var sut = new ValuesController();
            ActionResult result = sut.Post();
            var okResult = Assert.IsType<OkObjectResult>(result);  
            Assert.Equal("Batch job started", okResult.Value);
        }
    }
}
