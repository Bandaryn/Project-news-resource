using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Profile = AutoMapper.Profile;
using System.Threading.Tasks;
using FinalTest.Domain.Contracts.ViewModels;
using FinalTest.Data.Contracts.Entities;

namespace FinalTest.Infrastructure.MappingProfile
{
    public class ProfilMappingProfile:Profile
    {
        public ProfilMappingProfile()
        {
            MapProfileViewModelToProfil();
            MapProfilToProfileViewModel();
        }

        private void MapProfilToProfileViewModel()
        {
            CreateMap<Profil, ProfileViewModel>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, c => c.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, c => c.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, c => c.MapFrom(src => src.Email));
        }

        private void MapProfileViewModelToProfil()
        {
            CreateMap<ProfileViewModel, Profil>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, c => c.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, c => c.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, c => c.MapFrom(src => src.Email));
        }
    }
}
