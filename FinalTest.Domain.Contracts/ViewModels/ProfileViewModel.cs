using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.Domain.Contracts.ViewModels
{
    public class ProfileViewModel
    {
        public int Id { get; set; }
        public string Ids { get; set; }

        [Display(Name ="UserName",ResourceType =typeof(Resources.Resource))]
        public string UserName { get; set; }

        [Display(Name ="FirstName",ResourceType =typeof(Resources.Resource))]
        public string FirstName { get; set; }

        [Display(Name = "LastName", ResourceType = typeof(Resources.Resource))]
        public string LastName { get; set; }

        [Display(Name = "Email", ResourceType = typeof(Resources.Resource))]
        public string Email { get; set; }

        [Display(Name = "Roles", ResourceType = typeof(Resources.Resource))]
        public IList<string> Roles { get; set; }

        public ICollection<PostViewModel> Posts { get; set; }

        public bool IsEditable { get; set; }
    }
}
