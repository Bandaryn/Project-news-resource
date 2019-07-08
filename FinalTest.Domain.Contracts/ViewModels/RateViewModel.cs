using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.Domain.Contracts.ViewModels
{
    public class RateViewModel
    {
        public int Id { get; set; }

        public string AuthorIds { get; set; }

        public double RateValue { get; set; }

        public int PostId { get; set; }
    }
}
