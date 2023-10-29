using AutoMapper;
using DataAccessLayer.Entities;
using PresentationLayer.ViewModels;

namespace PresentationLayer.Mappers
{
    public class DepartmentProfile:Profile
    {
        public DepartmentProfile()
        {
            CreateMap<DepartmentViewModel,Department>().ReverseMap();
        }
    }
}
