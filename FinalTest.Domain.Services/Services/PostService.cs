using AutoMapper;
using FinalTest.Data.Contracts;
using FinalTest.Data.Contracts.Entities;
using FinalTest.Domain.Contracts;
using FinalTest.Domain.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.Domain.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository postRepository;
        private readonly IRepository<Section> sectionRepository;
        private readonly IProfileRepository profileRepository;
        private readonly ITagRepository tagRepository;


        public PostService(IPostRepository postRepository, IRepository<Section> sectionRepository,
            IProfileRepository profileRepository, ITagRepository tagRepository)
        {
            this.postRepository = postRepository;
            this.sectionRepository = sectionRepository;
            this.profileRepository = profileRepository;
            this.tagRepository = tagRepository;
        }


        public void Add(PostViewModel viewModel)
        {
                        
            Post post = Mapper.Map<Post>(viewModel);
            
            post.Section = sectionRepository.Get(viewModel.SectionId);
            post.Author = profileRepository.Get(viewModel.AuthorIds);

            

            if (viewModel.TagsName != null)
            {
                var tagList = ConvertToListTags(viewModel.TagsName);

                post.Tags = new List<Tag>();

                foreach (var tagName in tagList)
                {
                    var tag = tagRepository.GetName(tagName);
                    
                    post.Tags.Add(tag);

                }
            }

            postRepository.Add(post);
            postRepository.SaveChanges();
        }

        public void Delete(PostViewModel viewModel)
        {
            postRepository.Remove(viewModel.Id);
            postRepository.SaveChanges();
        }

        public PostViewModel Get(int id)
        {
            Post post = postRepository.Get(id);

            int summ=0;

            if((post!=null)&&(post.Rates != null))
            {
                foreach (var rate in post.Rates)
                {
                    summ += rate.RateValue;
                }

                if (post.Rates.Count != 0)
                {
                    post.Rating = summ / post.Rates.Count;
                }
                else post.Rating = 0;
            }
            
            
            
            var result = Mapper.Map<PostViewModel>(post);

            return result;
        }

        public List<PostViewModel> GetList()
        {
            List < Post > postList = postRepository.GetList();
            List<PostViewModel> postModelList = new List<PostViewModel>();
            foreach(var item in postList)
            {
                var result = Mapper.Map<PostViewModel>(item);
                postModelList.Add(result);
            }
            
            return postModelList;
        }

        public List<PostViewModel> Search(string request)
        {
            List<Post> postList = postRepository.Search(request);
            List<PostViewModel> postModelList = new List<PostViewModel>();

            foreach (var item in postList)
            {
                var result = Mapper.Map<PostViewModel>(item);
                postModelList.Add(result);
            }
            return postModelList;
        }

        public void Save(PostViewModel viewModel)
        {
            postRepository.SaveChanges();
        }

        public void Update(PostViewModel viewModel)
        {
            Post post = postRepository.Get(viewModel.Id);
            var result = Mapper.Map(viewModel, post);
            post.Section = sectionRepository.Get(viewModel.SectionId);

            if (viewModel.TagsName != null)
            {
                var tagList = ConvertToListTags(viewModel.TagsName);

                post.Tags = new List<Tag>();

                foreach (var tagName in tagList)
                {
                    var tag = tagRepository.GetName(tagName);

                    post.Tags.Add(tag);

                }
            }

            int summ = 0;
            if ((post != null) && (post.Rates != null))
            {
                foreach (var rate in post.Rates)
                {
                    summ += rate.RateValue;
                }

                if (post.Rates.Count != 0)
                {
                    post.Rating = summ / post.Rates.Count;
                }
                else post.Rating = 0;
            }

            postRepository.SaveChanges();
        }

        public IList<string> ConvertToListTags(string tags)
        {
            List<string> result = tags.Split(',').ToList();

            return result;

        }
    }
}
