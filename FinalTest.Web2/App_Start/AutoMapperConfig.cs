using AutoMapper;
using FinalTest.Infrastructure.MappingProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalTest.Web2.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(c => c.AddProfile(typeof(PostMappingProfile)));
            //Mapper.Initialize(c => c.AddProfile(typeof(ProfilMappingProfile)));
            //Mapper.Initialize(c => c.AddProfile(typeof(CommentMappingProfile)));
            //Mapper.Initialize(c => c.AddProfile(typeof(TagMappingProfile)));
        }
    }
}