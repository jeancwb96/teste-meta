using System.Threading.Tasks;
using Xunit;
using Api2.Contracts;
using Moq;
using Api2.Services;
using Api2.Utils;

namespace ApiTwo.Test
{
    public class CalcInterestRateServiceTest
    {
        private readonly Api2.Utils.Utils _utils;
        private readonly ICalcInterestRateService _service;
        
        public CalcInterestRateServiceTest(Api2.Utils.Utils utils)
        {
            _utils = utils;
            _service = new CalcInterestRateService(_utils);
        }

        public async Task InterestCalcTest(decimal initalValue, int time)
        {
            var result = await _service.CalcInterestRate(initalValue, time);
            Assert.Equal(105.10M, result);
        }
    }
}
