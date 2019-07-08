using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.Data.Contracts.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public virtual Profil Author { get; set; }
        public virtual Post Post { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Dislike> Dislikes { get; set; }

        public int LikesAmount { get; set; }
        public int DislikesAmount { get; set; }
    }
}
