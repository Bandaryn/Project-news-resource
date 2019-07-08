using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.Data.Contracts.Entities
{
    public class Rate
    {
        public int Id { get; set; }

        public string AuthorsIds { get; set; }

        public virtual Post Post { get; set; }

        public int RateValue { get; set; }

    }
}
