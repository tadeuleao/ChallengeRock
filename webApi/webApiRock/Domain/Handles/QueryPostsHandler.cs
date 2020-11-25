using AutoMapper;
using Core.Model;
using Core.Rules;
using Core.Rules.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using webApiRock.Domain.Commands.Request.Query;
using webApiRock.Domain.Commands.Response;

namespace webApiRock.Domain.Handles
{
    public class QueryPostsHandler : IRequestHandler<QueryPostRequest, IEnumerable<QueryPostResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IPostRule _postRule;
        private readonly IHistoryRule _historyRule;

        public QueryPostsHandler(IPostRule postRule, IMapper mapper, IHistoryRule historyRule )
        {
            _postRule = postRule;
            _historyRule = historyRule;
            _mapper = mapper;
        }

        public Task<IEnumerable<QueryPostResponse>> Handle(QueryPostRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.IdUser == 0)
                    throw new UserException("Error: User invalid");
                
                List<PostDTO> posts = new List<PostDTO>();

                if (request.PageCurrent == 0 || request.QuantityItems == 0)
                    posts = _postRule.ListAllPost();
                else
                    posts = _postRule.ListPaged(request.PageCurrent, request.QuantityItems);

                foreach (var post in posts)
                {
                    post.IsLiked = _historyRule.HasLikedPost(post.Handle , request.IdUser);
                }
                var result = _mapper.Map<IEnumerable<QueryPostResponse>>(posts);
                return Task.FromResult(result);
            }
            catch (Exception e)
            {
                throw new UserException("Error: " + e.Message);
            }
        }
    }
}
