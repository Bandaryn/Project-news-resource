using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.Domain.Contracts.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public int AuthorId { get; set; }

        [Display(Name ="Author",ResourceType =typeof(Resources.Resource))]
        public string AuthorName { get; set; }
        public string AuthorIds { get; set; }
        public int PostId { get; set; }

        public ICollection<LikeViewModel> Likes { get; set; }
        public int LikesAmount { get; set; }
        public ICollection<DislikeViewModel> Dislikes { get; set; }
        public int DislikesAmount { get; set; }

        public bool IsLikable { get; set; }
        public bool IsEditable { get; set; }
    }
}
