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
        private readonly IOperacao _operacao;
        private readonly IServiceProvider _provider;
        public WeatherForecastController(IOperacao operacao, IServiceProvider provider)
        {
            _operacao = operacao;
            _provider = provider;
        }

        [HttpGet("Construtor")]
        public IActionResult Construtor()
        {
            return Ok(_operacao.Id);
        }
        [HttpGet("Anotacao")]
        public IActionResult Anotacao([FromServices] IOperacao operacao)
        {
            return Ok(operacao.Id);
        }
        [HttpGet("Provider")]
        public IActionResult Provider()
        {
            return Ok(_provider.GetRequiredService<IOperacao>());
        }
    }
}
