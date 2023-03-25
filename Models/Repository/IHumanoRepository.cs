namespace Sithec2023.Models.Repository
{
    public interface IHumanoRepository
    {
        Task<List<Humano>> GetListHumanos();
        Task<Humano> GetHumano(int id);
        Task DeleteHumano(Humano alumno);
        Task<Humano> AddHumano(Humano alumno);
        Task UpdateHumano(Humano alumno);
    }
}
