using AutoMapper;
using DataAccessLayer.Entities;
using PresentationLayer.ViewModels;

namespace PresentationLayer.Mappers
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeViewModel, Employee>().ReverseMap();

        }
    } 
}
