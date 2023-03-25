using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sithec2023.Models;
using Sithec2023.Models.DTO;
using Sithec2023.Models.Repository;
using System.Globalization;

namespace Sithec2023.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAlumnoRepository _alumnoRepository;

        public AlumnoController(IMapper mapper, IAlumnoRepository alumnoRepository)
        {
            _alumnoRepository= alumnoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listAlumnos = await _alumnoRepository.GetListAlumnos();
                var listAlumnosDTO = _mapper.Map<IEnumerable<AlumnoDTO>>(listAlumnos);
                return Ok(listAlumnos);
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
                var alumno = await _alumnoRepository.GetAlumno(id);
                if (alumno == null)
                {
                    return NotFound();
                }
                var alumnoDTO = _mapper.Map<AlumnoDTO>(alumno);
                return Ok(alumnoDTO);
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
                var alumno = await _alumnoRepository.GetAlumno(id);
                if (alumno == null)
                {
                    return NotFound();
                }
                await _alumnoRepository.DeleteAlumno(alumno);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(AlumnoDTO alumnoDto)
        {
            try
            {
                var alumno = _mapper.Map<Alumno>(alumnoDto);

                alumno = await _alumnoRepository.AddAlumno(alumno);

                var alumnoItemDTO = _mapper.Map<AlumnoDTO>(alumno);

                return CreatedAtAction("Get", new { id = alumnoItemDTO.Id }, alumnoItemDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, AlumnoDTO alumnoDto)
        {
            try
            {
                var alumno = _mapper.Map<Alumno>(alumnoDto);

                if (id != alumno.Id)
                {
                    return BadRequest();
                }

                var alumnoItem = await _alumnoRepository.GetAlumno(id);

                if (alumnoItem == null)
                {
                    return NotFound();
                }

                await _alumnoRepository.UpdateAlumno(alumnoItem);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
