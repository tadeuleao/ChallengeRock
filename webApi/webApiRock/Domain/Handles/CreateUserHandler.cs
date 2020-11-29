using AutoMapper;
using Core.Model;
using Core.Rules;
using Core.Rules.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using webApiRock.Domain.Commands.Queries;
using webApiRock.Domain.Commands.Request.Create;
using webApiRock.Domain.Commands.Response;

namespace webApiRock.Domain.Handles
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, ReponseGeneric<CreateUserResponse>>
    {

        private readonly IMapper _mapper;
        private readonly IUserRule _userRule;

        public CreateUserHandler(IUserRule userRule, IMapper mapper)
        {
            _userRule = userRule;
            _mapper = mapper;
        }

        public Task<ReponseGeneric<CreateUserResponse>> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                ReponseGeneric<CreateUserResponse> result = new ReponseGeneric<CreateUserResponse>();
                if (string.IsNullOrEmpty(request.Login) || string.IsNullOrEmpty(request.Password))
                    throw new UserException("User or Password invalida");

                var dto = _mapper.Map<CreateUserRequest, UserDTO>(request);
                var user = _mapper.Map<UserDTO, CreateUserResponse>(_userRule.AddUser(dto));

                if (user.Id == 0){
                    result.Message = "It was not possible to register";
                    result.Success = true;
                    result.Data = user;
                }
                else
                {
                    result.Message = "User Add!";
                    result.Success = true;
                    result.Data = user;
                }               

                return Task.FromResult(result);
            }
            catch (UserException e)
            {
                throw new Exception("Error: " + e.Message);
            }
        }
    }
}
