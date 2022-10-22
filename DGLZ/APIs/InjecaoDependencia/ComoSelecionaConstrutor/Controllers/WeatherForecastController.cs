using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComoSelecionaConstrutor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IOperacao _operacao;
        public WeatherForecastController(IOperacao operacao)
        {
            _operacao = operacao;   
        }

        [HttpGet("Construtor")]
        public IActionResult Construtor()
        {
            return Ok(_operacao.Id);
        }
    }
}
