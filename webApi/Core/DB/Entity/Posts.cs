using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DB.Entity
{
    public class Posts
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public string Text { get; set; }
        public int Like { get; set; }
        public int DisLike { get; set; }
    }
}
