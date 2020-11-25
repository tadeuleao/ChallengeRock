using AutoMapper;
using Core.Model;
using Core.Rules;
using Core.Rules.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using webApiRock.Domain.Commands.Queries;
using webApiRock.Domain.Commands.Response;

namespace webApiRock.Domain.Handles
{
    public class QueryUserHandler : IRequestHandler<QueryUserRequest, ReponseGeneric<QueryUserResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRule _userRule;

        public QueryUserHandler(IUserRule user , IMapper mapper)
        {
            _userRule = user;
            _mapper = mapper;
        }

        public Task<ReponseGeneric<QueryUserResponse>> Handle(QueryUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                ReponseGeneric<QueryUserResponse> result = new ReponseGeneric<QueryUserResponse>();
                var user = _userRule.ListUser(request.Login, request.Password);
                if (user == null)
                {
                    result.Message = "User Invalid";
                    result.Success = false;
                }
                else
                {
                    result.Message = "User Is Authenticated.";
                    result.Success = true;
                    result.Data = _mapper.Map<UserDTO , QueryUserResponse>(user);
                }
                return Task.FromResult(result);
            }
            catch (UserException e)
            {
                throw new UserException("Error: " + e.Message);
            }
        }
    }
}
