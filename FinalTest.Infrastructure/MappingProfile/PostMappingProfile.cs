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
    public class PostMappingProfile:Profile
    {
        public PostMappingProfile()
        {
            MapPostToPostViewModel();
            MapPostViewModelToPost();
            MapCommentToCommentViewModel();
            MapCommentViewModelToComment();
            MapTagToTagViewModel();
            MapTagViewModelToTag();
            MapProfileViewModelToProfil();
            MapProfilToProfileViewModel();
            MapRateToRateViewModel();
            MapRateViewModelToRate();
            MapLikeToLikeViewModel();
            MapLikeViewModelToLike();
            MapDislikeToDislikeViewModel();
            MapDislikeViewModelToDislike();
        }

        private void MapPostToPostViewModel()
        {
            CreateMap<Post, PostViewModel>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, c => c.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, c => c.MapFrom(src => src.Description))
                .ForMember(dest =>dest.Text, c => c.MapFrom(src => src.Text))
                .ForMember(dest => dest.AuthorId, c => c.MapFrom(src => src.Author.Id))
                .ForMember(dest => dest.AuthorName, c => c.MapFrom(src => src.Author.UserName))
                .ForMember(dest => dest.AuthorIds, c => c.MapFrom(src => src.Author.Ids))
                .ForMember(dest => dest.SectionId, c => c.MapFrom(src => src.Section.Id))
                .ForMember(dest => dest.SectionName, c => c.MapFrom(src => src.Section.Name))
                .ForMember(dest => dest.Created, c=> c.MapFrom(src=>src.Created))
                .ForMember(dest =>dest.Rating, c=>c.MapFrom(src=> src.Rating));
        }
        
        private void MapPostViewModelToPost()
        {
            CreateMap<PostViewModel,Post>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, c => c.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, c => c.MapFrom(src => src.Description))
                .ForMember(dest => dest.Text, c => c.MapFrom(src => src.Text))
                //.ForMember(dest => dest.Author.Id, c => c.MapFrom(src => src.AuthorId))
                //.ForMember(dest => dest.Author.UserName, c => c.MapFrom(src => src.AuthorName))
                //.ForMember(dest => dest.Section.Id, c => c.MapFrom(src => src.SectionId))
                //.ForMember(dest => dest.Section.Name, c => c.MapFrom(src => src.SectionName))
                .ForMember(dest => dest.Created, c => c.MapFrom(src => src.Created))
                .ForMember(dest => dest.Rating, c => c.MapFrom(src => src.Rating))
                .ForAllOtherMembers(c => c.Ignore());
        }
        private void MapCommentToCommentViewModel()
        {
            CreateMap<Comment, CommentViewModel>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Body, c => c.MapFrom(src => src.Body))
                .ForMember(dest => dest.Likes, c => c.MapFrom(src => src.Likes))
                .ForMember(dest => dest.AuthorId, c => c.MapFrom(src => src.Author.Id))
                .ForMember(dest => dest.AuthorIds, c => c.MapFrom(src => src.Author.Ids))
                .ForMember(dest => dest.LikesAmount, c => c.MapFrom(src => src.LikesAmount))
                .ForMember(dest => dest.DislikesAmount, c => c.MapFrom(src => src.DislikesAmount))
                .ForMember(dest => dest.AuthorName, c => c.MapFrom(src => src.Author.UserName));
        }

        private void MapCommentViewModelToComment()
        {
            CreateMap<CommentViewModel, Comment>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Body, c => c.MapFrom(src => src.Body))
                .ForMember(dest => dest.LikesAmount, c => c.MapFrom(src => src.LikesAmount))
                .ForMember(dest => dest.DislikesAmount, c => c.MapFrom(src => src.DislikesAmount))
                .ForAllOtherMembers(c => c.Ignore());
            //.ForMember(dest => dest.Author.Id, c => c.MapFrom(src => src.AuthorId))
            //.ForMember(dest => dest.Author.UserName, c => c.MapFrom(src => src.AuthorName));
        }
        private void MapProfilToProfileViewModel()
        {
            CreateMap<Profil, ProfileViewModel>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Ids, c => c.MapFrom(src => src.Ids))
                .ForMember(dest => dest.UserName, c => c.MapFrom(src => src.UserName))
                .ForMember(dest => dest.FirstName, c => c.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, c => c.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, c => c.MapFrom(src => src.Email));
        }

        private void MapProfileViewModelToProfil()
        {
            CreateMap<ProfileViewModel, Profil>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Ids, c => c.MapFrom(src => src.Ids))
                .ForMember(dest => dest.UserName, c => c.MapFrom(src => src.UserName))
                .ForMember(dest => dest.FirstName, c => c.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, c => c.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, c => c.MapFrom(src => src.Email))
                .ForAllOtherMembers(c => c.Ignore());
        }

        private void MapTagToTagViewModel()
        {
            CreateMap<Tag, TagViewModel>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, c => c.MapFrom(src => src.Name));

        }

        private void MapTagViewModelToTag()
        {
            CreateMap<TagViewModel, Tag>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, c => c.MapFrom(src => src.Name));

        }

        private void MapRateToRateViewModel()
        {
            CreateMap<Rate, RateViewModel>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.RateValue, c => c.MapFrom(src => src.RateValue))
                .ForMember(dest => dest.AuthorIds, c => c.MapFrom(src => src.AuthorsIds));

        }

        private void MapRateViewModelToRate()
        {
            CreateMap<RateViewModel, Rate>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.RateValue, c => c.MapFrom(src => src.RateValue))
                .ForMember(dest => dest.AuthorsIds, c => c.MapFrom(src => src.AuthorIds));

        }

        private void MapLikeToLikeViewModel()
        {
            CreateMap<Like, LikeViewModel>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.AuthorIds, c => c.MapFrom(src => src.AuthorsIds));

        }

        private void MapLikeViewModelToLike()
        {
            CreateMap<LikeViewModel, Like>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.AuthorsIds, c => c.MapFrom(src => src.AuthorIds));

        }

        private void MapDislikeToDislikeViewModel()
        {
            CreateMap<Dislike, DislikeViewModel>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.AuthorIds, c => c.MapFrom(src => src.AuthorsIds));

        }

        private void MapDislikeViewModelToDislike()
        {
            CreateMap<DislikeViewModel, Dislike>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.AuthorsIds, c => c.MapFrom(src => src.AuthorIds));

        }
    }


}
