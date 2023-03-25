using Microsoft.EntityFrameworkCore;

namespace Sithec2023.Models.Repository
{
    public class AlumnoRepository:IAlumnoRepository
    {
        private readonly ApplicationDbContext _context;

        public AlumnoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Alumno> AddAlumno(Alumno alumno)
        {
            _context.Add(alumno);
            await _context.SaveChangesAsync();
            return alumno;
        }

        public async Task DeleteAlumno(Alumno alumno)
        {
            _context.Alumnos.Remove(alumno);
            await _context.SaveChangesAsync();
        }

        public async Task<Alumno> GetAlumno(int id)
        {
            return await _context.Alumnos.FindAsync(id);
        }

        public async Task<List<Alumno>> GetListAlumnos()
        {
            return await _context.Alumnos.ToListAsync();

        }

        public async Task UpdateAlumno(Alumno alumno)
        {
            var alumnoItem = await _context.Alumnos.FirstOrDefaultAsync(x => x.Id == alumno.Id);

            if (alumnoItem != null)
            {
                alumnoItem.Nombre = alumno.Nombre;
                alumnoItem.Edad = alumno.Edad;
                alumnoItem.Sexo = alumno.Sexo;
                alumnoItem.Estatura = alumno.Estatura;
                alumnoItem.Peso = alumno.Peso;

                await _context.SaveChangesAsync();

            }
        }
    }
}
