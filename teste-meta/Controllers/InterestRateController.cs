using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Api1.Controllers
{
    [ApiController]
    [Route("api1/taxajuros")]
    public class InterestRateController : ControllerBase
    {
        [HttpGet("ReturnInterestRate")]
        public async Task<decimal> ReturnInterestRate()
        {
            return await Task.FromResult(0.01M);
        }
    }
}



