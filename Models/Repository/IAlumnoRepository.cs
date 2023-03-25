namespace Sithec2023.Models.Repository
{
    public interface IAlumnoRepository
    {
        Task<List<Alumno>> GetListAlumnos();
        Task<Alumno> GetAlumno(int id);
        Task DeleteAlumno(Alumno alumno);
        Task<Alumno> AddAlumno(Alumno alumno);
        Task UpdateAlumno(Alumno alumno);
    }
}
