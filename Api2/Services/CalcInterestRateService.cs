using System;
using System.Threading.Tasks;
using Api2.Contracts;

namespace Api2.Services
{
    public class CalcInterestRateService : ICalcInterestRateService
    {
        private readonly Api2.Utils.Utils _utils;
        public CalcInterestRateService(Api2.Utils.Utils utils)
        {
            _utils = utils;
        }
        public async Task<decimal> CalcInterestRate(decimal initialValue, int time)
        {
            var endpoint = _utils.URIStringBuilder("http://localhost:50131/api1", "taxajuros", "ReturnInterestRate");
            var compoundInterest = 1 + (double)await _utils.CallRestAPI<decimal>(Enums.HttpMethodEnum.GET, endpoint); ;         
            return (decimal)Math.Round((Math.Pow(compoundInterest, time) * (double)initialValue), 2);
        }
    }
}