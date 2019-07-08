namespace FinalTest.Data.EntityFrame
{
    using FinalTest.Data.Contracts.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class PostContext : DbContext
    {
        
        public PostContext()
            : base("name=PostContext2")
        {
        }

       
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Profil> Profiles { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Dislike> Dislikes { get; set; }
        public DbSet<Rate> Rates { get; set; }
        


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PostTypeConfiguration());
            
            modelBuilder.Configurations.Add(new CommentTypeConfiguration());
            modelBuilder.Configurations.Add(new LikeTypeConfiguration());
            modelBuilder.Configurations.Add(new DislikeTypeConfiguration());
            modelBuilder.Configurations.Add(new RateTypeConfiguration());
            //modelBuilder.Configurations.Add(new TagTypeConfiguration());

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();


        }
    }
   
    public class CommentTypeConfiguration: EntityTypeConfiguration<Comment>
    {
        public CommentTypeConfiguration()
        {
            HasRequired(x => x.Author).WithMany(x=>x.Comments);
            HasRequired(x => x.Post).WithMany(x => x.Comments);
            
        }
    }

    

    public class PostTypeConfiguration : EntityTypeConfiguration<Post>
    {
        public PostTypeConfiguration()
        {
            
            Property(x => x.Title).IsRequired();

            HasRequired(x => x.Author).WithMany(x => x.Posts);
            HasRequired(x => x.Section).WithMany(x => x.Posts);
            HasMany(x => x.Tags).WithMany(x => x.Posts);
        }
    }

    public class LikeTypeConfiguration : EntityTypeConfiguration<Like>
    {
        public LikeTypeConfiguration()
        {
            
            HasRequired(x => x.Comment).WithMany(x => x.Likes);
            
        }
    }
    public class DislikeTypeConfiguration : EntityTypeConfiguration<Dislike>
    {
        public DislikeTypeConfiguration()
        {

            HasRequired(x => x.Comment).WithMany(x => x.Dislikes);

        }
    }

    public class RateTypeConfiguration : EntityTypeConfiguration<Rate>
    {
        public RateTypeConfiguration()
        {

            HasRequired(x => x.Post).WithMany(x => x.Rates);

        }
    }

    //public class TagTypeConfiguration : EntityTypeConfiguration<Tag>
    //{
    //    public TagTypeConfiguration()
    //    {

    //        HasMany(x => x.Posts).WithMany(x => x.Tags);

    //    }
    //}

}