using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApiRock.Domain.Commands.Response;

namespace webApiRock.Domain.Commands.Request.Create
{
    public class CreatePostRequest : IRequest<CreatePostResponse>
    {
        public string Tittle { get; set; }
        public string Text { get; set; }
    }
}
