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
    public class TagService : ITagService
    {
        private readonly ITagRepository repository;
        private readonly IPostRepository postRepository;

        public TagService(ITagRepository repository, IPostRepository postRepository)
        {
            this.repository = repository;
            this.postRepository = postRepository;
        }

        public void Add(TagViewModel viewModel)
        {
            Tag tag = Mapper.Map<Tag>(viewModel);
            repository.Add(tag);
            repository.SaveChanges();
        }

        public void AddFromPost(PostViewModel viewModel)
        {
            if(viewModel.TagsName != null)
            {
                var tagList = ConvertToListTags(viewModel.TagsName);

                foreach (var tagName in tagList)
                {
                    if (repository.GetName(tagName) == null)
                    {
                        TagViewModel tagViewModel = new TagViewModel()
                        {
                            Name = tagName

                        };

                        bool found = false;
                        int i = 1;
                        do
                        {
                            if (Get(i) != null)
                            {
                                i++;
                            }
                            else
                            {
                                found = true;
                            }
                        }
                        while (found == false);
                        
                        tagViewModel.Id = i;
                        Add(tagViewModel);
                        
                    }
                }
            }
            

        }

        public void Delete(TagViewModel viewModel)
        {            
            repository.Remove(viewModel.Id);
            repository.SaveChanges();
        }

        public TagViewModel Get(int id)
        {
            Tag tag = repository.Get(id);

            var result = Mapper.Map<TagViewModel>(tag);

            return result;
        }

        public List<TagViewModel> GetList()
        {
            List<Tag> tagList = repository.GetList();
            List<TagViewModel> tagModelList = new List<TagViewModel>();
            foreach (var item in tagList)
            {
                var result = Mapper.Map<TagViewModel>(item);
                tagModelList.Add(result);
            }
            return tagModelList;
        }

        public void Save(TagViewModel viewModel)
        {
            repository.SaveChanges();
        }

        public void Update(TagViewModel viewModel)
        {
            Tag tag = repository.Get(viewModel.Id);
            var result = Mapper.Map(viewModel, tag);

            repository.SaveChanges();
        }

        public IList<string> ConvertToListTags(string tags)
        {
            List<string> result = tags.Split(',').ToList();

            return result;

        }
    }
}
