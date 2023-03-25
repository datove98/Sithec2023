using AutoMapper;
using Sithec2023.Models.DTO;

namespace Sithec2023.Models.Profiles
{
    public class HumanoProfile:Profile
    {
        public HumanoProfile()
        {
            CreateMap<Humano, HumanoDTO>();

            CreateMap<HumanoDTO, Humano>();
        }
    }
}
