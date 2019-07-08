using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FinalTest.Domain.Contracts.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Title", ResourceType = typeof(Resources.Resource))]
        public string Title { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Resources.Resource))]
        public string Description { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name ="Text",ResourceType =typeof(Resources.Resource))]
        public string Text { get; set; }

        public int AuthorId { get; set; }

        [Display(Name = "Author", ResourceType = typeof(Resources.Resource))]
        public string AuthorName { get; set; }
        public string AuthorIds { get; set; }

        [Display(Name = "Section", ResourceType = typeof(Resources.Resource))]
        public int SectionId { get; set; }
        [Display(Name ="Section",ResourceType =typeof(Resources.Resource))]
        public string SectionName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Created", ResourceType = typeof(Resources.Resource))]
        public DateTime Created { get; set; }

        [Display(Name = "Tags", ResourceType = typeof(Resources.Resource))]
        public string TagsName { get; set; }

        [Display(Name = "Rating", ResourceType = typeof(Resources.Resource))]
        public int Rating { get; set; }

        public IList<SelectListItem> SectionsAvailable { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }
        public IList<TagViewModel> Tags { get; set; }  //changed from ICOllection
        
        public ICollection<RateViewModel> Rates { get; set; }

        public bool IsRatable { get; set; }
        public bool IsCommentable { get; set; }

        public string[] TagSuggested { get; set; }
    }
}
