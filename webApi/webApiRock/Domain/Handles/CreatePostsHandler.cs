using AutoMapper;
using Core.Model;
using Core.Rules;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using webApiRock.Domain.Commands.Request.Create;
using webApiRock.Domain.Commands.Response;

namespace webApiRock.Domain.Handles
{
    public class CreatePostsHandler : IRequestHandler<CreatePostRequest, CreatePostResponse>
    {

        private readonly IMapper _mapper;
        private readonly IPostRule _postRule;
        private readonly IHistoryRule _historyRule;

        public CreatePostsHandler(IPostRule postRule, IMapper mapper, IHistoryRule historyRule)
        {
            _postRule = postRule;
            _historyRule = historyRule;
            _mapper = mapper;
        }

        public Task<CreatePostResponse> Handle(CreatePostRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var dto = _mapper.Map<CreatePostRequest , PostDTO>(request);
                var post = _mapper.Map<int, CreatePostResponse>(_postRule.SavePost(dto));
                return Task.FromResult(post);
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e.Message);
            }
        }
    }
}
