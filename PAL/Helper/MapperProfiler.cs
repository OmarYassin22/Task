using AutoMapper;
using DAL.Model;
using PAL.ViewModels;

namespace PAL.Helper
{
    public class MapperProfiler : Profile
    {

        public MapperProfiler()
        {
            CreateMap<Applicant, ApplicantDTO>().ReverseMap();
        }


    }
}
