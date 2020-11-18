using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Api1
{
    [Route("api1/health")]
    public class HealthController : ControllerBase
    {
        public HealthController()
        {
        }

        [HttpGet]
        [Route("isalive")]
        public ActionResult IsAlive()
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}