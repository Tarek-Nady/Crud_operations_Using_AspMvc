using AutoMapper;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using PresentationLayer.ViewModels;

namespace PresentationLayer.Mappers
{
    public class RegisterationProfile:Profile
    {
        public RegisterationProfile()
        {
            CreateMap<RegisterViewModel,ApplicationUser>().ReverseMap();
        }
    }
}
