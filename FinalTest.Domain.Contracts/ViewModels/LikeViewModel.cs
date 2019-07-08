using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.Domain.Contracts.ViewModels
{
    public class LikeViewModel
    {
        public int Id { get; set; }

        public string AuthorIds { get; set; }

        public int CommentId { get; set; }
    }
}
