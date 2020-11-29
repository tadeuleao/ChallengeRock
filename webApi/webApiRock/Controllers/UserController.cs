using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using webApiRock.Domain.Commands.Queries;
using webApiRock.Domain.Commands.Request.Create;
using webApiRock.Domain.Commands.Response;

namespace webApiRock.Controllers
{

    [ApiController]
    [Route("api/v1")]
    public class UserController : Controller
    {
        
        [HttpPost]
        [Route("Auth")]
        public Task<ReponseGeneric<QueryUserResponse>> Post([FromServices] IMediator mediator , [FromBody] QueryUserRequest command)
        {
            return mediator.Send(command);
        }

        [HttpPost]
        [Route("AddUser")]
        public Task<ReponseGeneric<CreateUserResponse>> Put([FromServices] IMediator mediator, [FromBody] CreateUserRequest command)
        {
            return mediator.Send(command);
        }
    }
}
