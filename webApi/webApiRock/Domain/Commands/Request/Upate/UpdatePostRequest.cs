using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApiRock.Domain.Commands.Response;

namespace webApiRock.Domain.Commands.Request.Upate
{
    public class UpdatePostRequest : IRequest<UpdatePostResponse>
    {
        public int IdPost { get; set; }
        public int IdUser { get; set; }
    }
}
