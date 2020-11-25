using AutoMapper;
using Core.Model;
using Core.Rules;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using webApiRock.Domain.Commands.Request.Upate;
using webApiRock.Domain.Commands.Response;

namespace webApiRock.Domain.Handles
{
    public class UpdatePostsHandler : IRequestHandler<UpdatePostRequest , UpdatePostResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPostRule _postRule;
        private readonly IHistoryRule _historyRule;

        public UpdatePostsHandler(IPostRule postRule, IMapper mapper, IHistoryRule historyRule)
        {
            _postRule = postRule;
            _historyRule = historyRule;
            _mapper = mapper;
        }

        public Task<UpdatePostResponse> Handle(UpdatePostRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.IdPost == null || request.IdUser == null)
                {
                    throw new Exception("Erro: User or Post is empty.");
                }
                var post = _mapper.Map<bool, UpdatePostResponse>(_postRule.LikePost(request.IdPost, request.IdUser));
                return Task.FromResult(post);
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e.Message);
            }
        }
    }
}
