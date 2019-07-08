using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.Data.Contracts.Entities
{
    public class Dislike
    {
        public int Id { get; set; }

        public string AuthorsIds { get; set; }
        public virtual Comment Comment { get; set; }
    }
}
