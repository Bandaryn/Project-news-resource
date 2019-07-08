using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.Domain.Contracts.ViewModels
{
    public class TagViewModel
    {
        public int Id { get; set; }

        [Display(Name="Tag",ResourceType =typeof(Resources.Resource))]
        public string Name { get; set; }

        public ICollection<PostViewModel> Posts { get; set; }
    }
}
