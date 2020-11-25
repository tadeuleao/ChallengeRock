using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApiRock.Domain.Commands.Response;

namespace webApiRock.Domain.Commands.Request.Query
{
    public class QueryPostRequest : IRequest<IEnumerable<QueryPostResponse>>
    {
        public int IdUser { get; set; }
        public int PageCurrent { get; set; }
        public int QuantityItems { get; set; }
    }
}
