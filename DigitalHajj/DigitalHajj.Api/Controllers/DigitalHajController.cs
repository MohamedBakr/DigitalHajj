using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalHajj.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalHajj.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/DigitalHaj")]
    public class DigitalHajController : Controller
    {
        public DigitalHajController(CrowdCounterBl crowdCounterBl)
        {
            CrowdCounterBl = crowdCounterBl;
        }

        public CrowdCounterBl CrowdCounterBl { get; }

        [HttpGet("GetAirportStatus")]
        public IActionResult GetAirportStatus()
        {
            return Ok(CrowdCounterBl.GetAirPortsStatus());
        }

        [HttpGet("GetAirportStatus/{airport}")]
        public IActionResult GetAirportStatus(int airport)
        {
            return Ok(CrowdCounterBl.GetAirPortStatus(airport));
        }
    }
}