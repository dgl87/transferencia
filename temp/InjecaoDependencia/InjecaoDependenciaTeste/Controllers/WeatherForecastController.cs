using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InjecaoDependenciaTeste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet("atributo")]
        public IActionResult Atributo([FromServices] IOperacao operacao)
        {
            return Ok(operacao.Id);
        }
    }
}
