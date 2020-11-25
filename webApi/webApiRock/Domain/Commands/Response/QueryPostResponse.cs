using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApiRock.Domain.Commands.Response
{
    public class QueryPostResponse
    {
        public int Handle { get; set; }
        public string Tittle { get; set; }
        public string Text { get; set; }
        public int Like { get; set; }
        public bool IsLiked { get; set; }
        public int DisLike { get; set; }
    }
}
