using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Sithec2023.Models;
using Sithec2023.Models.DTO;
using Sithec2023.Models.Repository;
using System.Globalization;

namespace Sithec2023.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class HumanoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IHumanoRepository _humanoRepository;

        public HumanoController(IMapper mapper, IHumanoRepository alumnoRepository)
        {
            _humanoRepository= alumnoRepository;
            _mapper = mapper;
        }

        [HttpGet("Mock")]
        public IActionResult GetWithMock()
        {
            try
            {
                var humanos = new Humano[]
                {
                    new Humano{ Id = 1, Nombre = "Juan", Edad = 30, Estatura= (float)1.70, Peso = (float)86, Sexo="Masculino" },
                    new Humano{ Id = 2, Nombre = "María", Edad = 25, Estatura= (float)1.70, Peso = (float)86, Sexo="Femenino"  },
                    new Humano{ Id = 3, Nombre = "Pedro", Edad = 40 ,  Estatura= (float)1.70, Peso = (float)86, Sexo="Masculino" }
                };
                return Ok(humanos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listHumanos = await _humanoRepository.GetListHumanos();
                var listHumanosDTO = _mapper.Map<IEnumerable<HumanoDTO>>(listHumanos);
                return Ok(listHumanos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTest()
        {
            try
            {
                var listHumanos = await _humanoRepository.GetListHumanos();
                var listHumanosDTO = _mapper.Map<IEnumerable<HumanoDTO>>(listHumanos);
                return Ok(listHumanos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetTodos()
        {
            try
            {
                var listHumanos = await _humanoRepository.GetListHumanos();
                var listHumanosDTO = _mapper.Map<IEnumerable<HumanoDTO>>(listHumanos);
                return Ok(listHumanos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var humano = await _humanoRepository.GetHumano(id);
                if (humano == null)
                {
                    return NotFound();
                }
                var humanoDTO = _mapper.Map<HumanoDTO>(humano);
                return Ok(humanoDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var humano = await _humanoRepository.GetHumano(id);
                if (humano == null)
                {
                    return NotFound();
                }
                await _humanoRepository.DeleteHumano(humano);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(HumanoDTO humanoDto)
        {
            try
            {
                var humano = _mapper.Map<Humano>(humanoDto);

                humano = await _humanoRepository.AddHumano(humano);

                var humanoItemDTO = _mapper.Map<HumanoDTO>(humano);

                return CreatedAtAction("Get", new { id = humanoItemDTO.Id }, humanoItemDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, HumanoDTO humanoDto)
        {
            try
            {
                var humano = _mapper.Map<Humano>(humanoDto);

                if (id != humano.Id)
                {
                    return BadRequest();
                }

                var humanoItem = await _humanoRepository.GetHumano(id);

                if (humanoItem == null)
                {
                    return NotFound();
                }

                await _humanoRepository.UpdateHumano(humanoItem);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
