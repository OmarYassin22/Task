using AutoMapper;
using BL.ViewModels;
using DAL.Model;

namespace BL.Helper
{
    public class MapperProfiler : Profile
    {

        public MapperProfiler()
        {
            CreateMap<Applicant, ApplicantDTO>().ReverseMap();
        }


    }
}
