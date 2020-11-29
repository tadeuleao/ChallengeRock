using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApiRock.Domain.Commands.Response;

namespace webApiRock.Domain.Commands.Request.Create
{
    public class CreateUserRequest : IRequest<ReponseGeneric<CreateUserResponse>>
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}
