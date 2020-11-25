using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class PostDTO
    {
        public int Handle { get; set; }
        public string Tittle { get; set; }
        public string Text { get; set; }
        public int Like { get; set; }
        public bool IsLiked { get; set; }
        public int DisLike { get; set; }
    }
}
