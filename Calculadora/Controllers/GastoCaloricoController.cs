using Calculadora.Models;
using Microsoft.AspNetCore.Mvc;

namespace Calculadora.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GastoCaloricoController : ControllerBase
    {

        [HttpPost("CalcularGastoCalorico")]
        public IActionResult GastoCaloricoBasal(GastoCaloricoModel dados)
        {
            var gastoCalorico = new GastoCaloricoModel();

            if(dados.IdadeEmAnos < 18 || dados.IdadeEmAnos > 40)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Não conseguimos realizar o calculo para a idade informada."
                });
            } else if(dados.IdadeEmAnos >= 18 || dados.IdadeEmAnos <= 30)
            {
                var resultado = gastoCalorico.CalculoEntre18E30Anos(dados);

                return Ok(new
                {
                    success = true,
                    gastoCalorico = Convert.ToInt32(resultado)
                });
            }else
            {
                var resultado = gastoCalorico.CalculoEntre31E40Anos(dados);

                return Ok(new
                {
                    success = true,
                    gastoCalorico = Convert.ToInt32(resultado)
                });
            }
        }

        [HttpPost("CalcularGastoAtividade")]
        public IActionResult GastoCaloricoAtividade(GastoAtividadeModel dados)
        {
            var gastoAtividade = new GastoAtividadeModel();

            List<string> atividadesDisponiveis = new List<string>() {"Caminhada (piso plano)", "Trabalho doméstico", "Corrida (5 min/Km)", "Bicicleta (9 km/h)", "Bicicleta (15 Km/h)", "Alongamento" };

            foreach(var item in atividadesDisponiveis)
            {
                if (item == dados.AtividadeRealizada)
                {
                    var resultado = gastoAtividade.Calculo(dados);
                    return Ok(new
                    {
                        success = true,
                        gastoAtividade = resultado
                    });
                }
            }

            return BadRequest(new
            {
                success = false,
                message = "Atividade não existe, calculo não pode ser realizado"
            });
        }
    }
}