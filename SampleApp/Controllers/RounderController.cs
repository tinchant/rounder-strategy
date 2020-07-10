using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleDomain;

namespace SampleApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RounderController : ControllerBase
    {
        [HttpGet("{id}")]
        public decimal Get(decimal id, [FromServices]RounderService rounderService) 
            => rounderService.Round(id);

    }
}