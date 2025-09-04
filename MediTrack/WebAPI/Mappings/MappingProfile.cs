using AutoMapper;
using MediTrack.Core.Models;
using MediTrack.WebAPI.Dtos;

namespace MediTrack.WebAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        { 

           CreateMap<Patient , PatientDto>().ReverseMap();
           

        }
    }
}
