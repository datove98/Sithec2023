using Microsoft.EntityFrameworkCore;

namespace Sithec2023.Models.Repository
{
    public class HumanoRepository:IHumanoRepository
    {
        private readonly ApplicationDbContext _context;

        public HumanoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Humano> AddHumano(Humano alumno)
        {
            _context.Add(alumno);
            await _context.SaveChangesAsync();
            return alumno;
        }

        public async Task DeleteHumano(Humano alumno)
        {
            _context.Humanos.Remove(alumno);
            await _context.SaveChangesAsync();
        }

        public async Task<Humano> GetHumano(int id)
        {
            return await _context.Humanos.FindAsync(id);
        }

        public async Task<List<Humano>> GetListHumanos()
        {
            return await _context.Humanos.ToListAsync();

        }

        public async Task UpdateHumano(Humano alumno)
        {
            var alumnoItem = await _context.Humanos.FirstOrDefaultAsync(x => x.Id == alumno.Id);

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
