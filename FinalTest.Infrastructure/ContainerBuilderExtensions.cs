using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using System.Threading.Tasks;
using FinalTest.Data.EntityFrame;
using FinalTest.Data.Contracts;
using FinalTest.Domain.Services;
using FinalTest.Domain.Contracts;
using FinalTest.Data.EntityFrame.Repositories;
using FinalTest.Data.Contracts.IRepositories;
using FinalTest.Domain.Contracts.ServiceInterfaces;

namespace FinalTest.Infrastructure
{
    public static class ContainerBuilderExtensions
    {
        public static ContainerBuilder AddDataDependencies(this ContainerBuilder builder)
        {            
            builder.RegisterType<PostContext>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<ProfileRepository>().As<IProfileRepository>().InstancePerLifetimeScope();
            builder.RegisterType<TagRepository>().As<ITagRepository>().InstancePerLifetimeScope();
            builder.RegisterType<PostRepository>().As<IPostRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CommentRepository>().As<ICommentRepository>().InstancePerLifetimeScope();
            builder.RegisterType<LikeRepository>().As<ILikeRepository>().InstancePerLifetimeScope();
            builder.RegisterType<DislikeRepository>().As<IDislikeRepository>().InstancePerLifetimeScope();
            builder.RegisterType<RateRepository>().As<IRateRepository>().InstancePerLifetimeScope();
            return builder;
        }

        public static ContainerBuilder AddDomainDependencies(this ContainerBuilder builder)
        {
            builder.RegisterType<PostService>().As<IPostService>().InstancePerLifetimeScope();
            builder.RegisterType<ProfileService>().As<IProfileService>().InstancePerLifetimeScope();
            builder.RegisterType<TagService>().As<ITagService>().InstancePerLifetimeScope();
            builder.RegisterType<CommentService>().As<ICommentService>().InstancePerLifetimeScope();
            builder.RegisterType<LikeService>().As<ILikeService>().InstancePerLifetimeScope();
            builder.RegisterType<DislikeService>().As<IDislikeService>().InstancePerLifetimeScope();
            builder.RegisterType<RateService>().As<IRateService>().InstancePerLifetimeScope();

            return builder;
        }
    }
}
