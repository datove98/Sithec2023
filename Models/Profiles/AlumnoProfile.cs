using AutoMapper;
using Sithec2023.Models.DTO;

namespace Sithec2023.Models.Profiles
{
    public class AlumnoProfile:Profile
    {
        public AlumnoProfile()
        {
            CreateMap<Alumno, AlumnoDTO>();

            CreateMap<AlumnoDTO, Alumno>();
        }
    }
}
