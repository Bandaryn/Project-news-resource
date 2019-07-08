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
    public class CommentMappingProfile:Profile
    {
        public CommentMappingProfile()
        {
            MapCommentToCommentViewModel();
            MapCommentViewModelToComment();
        }

        private void MapCommentToCommentViewModel()
        {
            CreateMap<Comment, CommentViewModel>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Body, c => c.MapFrom(src => src.Body))
                .ForMember(dest => dest.Likes, c => c.MapFrom(src => src.Likes))                
                .ForMember(dest => dest.AuthorId, c => c.MapFrom(src => src.Author.Id))
                .ForMember(dest => dest.AuthorName, c => c.MapFrom(src => src.Author.UserName));
        }

        private void MapCommentViewModelToComment()
        {
            CreateMap<CommentViewModel, Comment>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Body, c => c.MapFrom(src => src.Body))
                .ForMember(dest => dest.Likes, c => c.MapFrom(src => src.Likes));
                //.ForMember(dest => dest.Author.Id, c => c.MapFrom(src => src.AuthorId))
                //.ForMember(dest => dest.Author.UserName, c => c.MapFrom(src => src.AuthorName));
        }

    }
}
