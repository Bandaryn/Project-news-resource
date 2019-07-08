using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Profile = AutoMapper.Profile;
using System.Threading.Tasks;
using FinalTest.Data.Contracts.Entities;
using FinalTest.Domain.Contracts.ViewModels;

namespace FinalTest.Infrastructure.MappingProfile
{
    public class TagMappingProfile: Profile
    {
        public TagMappingProfile()
        {
            MapTagToTagViewModel();
            MapTagViewModelToTag();
        }

        private void MapTagToTagViewModel()
        {
            CreateMap<Tag, TagViewModel>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, c => c.MapFrom(src => src.Name));
                
        }

        private void MapTagViewModelToTag()
        {
            CreateMap<TagViewModel,Tag>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, c => c.MapFrom(src => src.Name));

        }
    }
}
