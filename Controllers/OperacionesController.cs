using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sithec2023.Models;
using System.Text.RegularExpressions;

namespace Sithec2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperacionesController : ControllerBase
    {
        [HttpGet("suma")]
        public IActionResult Suma(string sumValor1, string sumValor2, string sumValor3)
        {
            try
            {
                Regex regex = new Regex(@"^\d+(\.\d+)?$");
                decimal valor1 = 0,valor2 =0, valor3 = 0;

                if (regex.IsMatch(sumValor1)) valor1 = decimal.Parse(sumValor1);

                if (regex.IsMatch(sumValor2)) valor2 = decimal.Parse(sumValor2);

                if (regex.IsMatch(sumValor3)) valor3 = decimal.Parse(sumValor3);

                decimal suma = valor1 + valor2 + valor3;
                return Ok(suma);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("suma")]
        public IActionResult Suma(OperacionesArgumentos argumentos)
        {
            try
            {
                Regex regex = new Regex(@"^\d+(\.\d+)?$");
                decimal valor1 = 0, valor2 = 0, valor3 = 0;

                if (regex.IsMatch(argumentos.Dato1)) valor1 = decimal.Parse(argumentos.Dato1);

                if (regex.IsMatch(argumentos.Dato2)) valor2 = decimal.Parse(argumentos.Dato2);

                if (regex.IsMatch(argumentos.Dato3)) valor3 = decimal.Parse(argumentos.Dato3);

                decimal suma = valor1 + valor2 + valor3;
                return Ok(suma);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("resta")]
        public IActionResult Resta(string resValor1, string resValor2, string resValor3)
        {
            try
            {
                Regex regex = new Regex(@"^\d+(\.\d+)?$");
                decimal valor1 = 0, valor2 = 0, valor3 = 0;

                if (regex.IsMatch(resValor1)) valor1 = decimal.Parse(resValor1);

                if (regex.IsMatch(resValor2)) valor2 = decimal.Parse(resValor2);

                if (regex.IsMatch(resValor3)) valor3 = decimal.Parse(resValor3);

                decimal resta = valor1 - valor2 - valor3;
                return Ok(resta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("resta")]
        public IActionResult Resta(OperacionesArgumentos argumentos)
        {
            try
            {
                Regex regex = new Regex(@"^\d+(\.\d+)?$");
                decimal valor1 = 0, valor2 = 0, valor3 = 0;

                if (regex.IsMatch(argumentos.Dato1)) valor1 = decimal.Parse(argumentos.Dato1);

                if (regex.IsMatch(argumentos.Dato2)) valor2 = decimal.Parse(argumentos.Dato2);

                if (regex.IsMatch(argumentos.Dato3)) valor3 = decimal.Parse(argumentos.Dato3);

                decimal resta = valor1 - valor2 - valor3;
                return Ok(resta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("multiplicacion")]
        public IActionResult Multiplicacion(string multValor1, string multValor2, string multpValor3)
        {
            try
            {
                Regex regex = new Regex(@"^\d+(\.\d+)?$");
                decimal multiplicacion = 0;
                decimal valor1 = 0, valor2 = 0, valor3 = 0;

                if (regex.IsMatch(multValor1)) valor1 = decimal.Parse(multValor1);

                if (regex.IsMatch(multValor2)) valor2 = decimal.Parse(multValor2);

                if (regex.IsMatch(multpValor3)) valor3 = decimal.Parse(multpValor3);

                multiplicacion = valor1 * valor2 * valor3;
                return Ok(multiplicacion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("multiplicacion")]
        public IActionResult Multiplicacion(OperacionesArgumentos argumentos)
        {
            try
            {
                Regex regex = new Regex(@"^\d+(\.\d+)?$");
                decimal multiplicacion = 0;
                decimal valor1 = 0, valor2 = 0, valor3 = 0;

                if (regex.IsMatch(argumentos.Dato1)) valor1 = decimal.Parse(argumentos.Dato1);

                if (regex.IsMatch(argumentos.Dato2)) valor2 = decimal.Parse(argumentos.Dato2);

                if (regex.IsMatch(argumentos.Dato3)) valor3 = decimal.Parse(argumentos.Dato3);

                multiplicacion = valor1 * valor2 * valor3;
                return Ok(multiplicacion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("division")]
        public IActionResult Division(string dividendo, string divisor1, string divisor2)
        {
            try
            {
                Regex regex = new Regex(@"^\d+(\.\d+)?$");
                decimal divResultado = 0;
                decimal valor1 = 0, valor2 = 0, valor3 = 0;

                if (regex.IsMatch(dividendo)) valor1 = decimal.Parse(dividendo);

                if (regex.IsMatch(divisor1)) valor2 = decimal.Parse(divisor1);

                if (regex.IsMatch(divisor2)) valor3 = decimal.Parse(divisor2);

                if (valor2 == 0 || valor3 == 0) return BadRequest("No se puede dividir entre 0");

                divResultado = (decimal)((valor1 / valor2) / (decimal)valor3);
                return Ok(divResultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("division")]
        public IActionResult Division(OperacionesArgumentosDivision argumentos)
        {
            try
            {
                Regex regex = new Regex(@"^\d+(\.\d+)?$");
                decimal divResultado = 0;
                decimal valor1 = 0, valor2 = 0, valor3 = 0;

                if (regex.IsMatch(argumentos.Dividendo)) valor1 = decimal.Parse(argumentos.Dividendo);

                if (regex.IsMatch(argumentos.Divisor1)) valor2 = decimal.Parse(argumentos.Divisor1);

                if (regex.IsMatch(argumentos.Divisor2)) valor3 = decimal.Parse(argumentos.Divisor2);

                if (valor2 == 0 || valor3 == 0) return BadRequest("No se puede dividir entre 0");

                divResultado = ((valor1 / valor2) /valor3);
                return Ok(divResultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
