using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using webApiRock.Domain.Commands.Request.Create;
using webApiRock.Domain.Commands.Request.Query;
using webApiRock.Domain.Commands.Request.Upate;
using webApiRock.Domain.Commands.Response;

namespace webApiRock.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class PostsController : Controller
    {
        [HttpGet]
        [Route("Posts")]
        public Task<IEnumerable<QueryPostResponse>> Get([FromServices] IMediator mediator, [FromQuery] QueryPostRequest command)
        {
            return mediator.Send(command);
        }

        [HttpPost]
        [Route("Create")]
        public Task<CreatePostResponse> Post([FromServices] IMediator mediator, [FromBody] CreatePostRequest command)
        {
            return mediator.Send(command);
        }

        [HttpPut]
        [Route("LikePost")]
        public Task<UpdatePostResponse> Put([FromServices] IMediator mediator, [FromBody] UpdatePostRequest command)
        {
            return mediator.Send(command);
        }
    }
}
