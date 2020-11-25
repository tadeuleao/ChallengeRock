using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApiRock.Domain.Commands.Response;

namespace webApiRock.Domain.Commands.Queries
{
    public class QueryUserRequest : IRequest<ReponseGeneric<QueryUserResponse>>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
