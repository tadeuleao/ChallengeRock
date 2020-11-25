using AutoMapper;
using Core.DB.Context;
using Core.DB.Entity;
using Core.Model;
using Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Rules
{
    public class PostRule : IPostRule
    {
        private readonly PostsContext _context;
        private readonly IMapper _mapper;
        private readonly Repository<Posts> _postRepository;
        private readonly IHistoryRule _historyRule;
        
        public PostRule(IMapper mapper , PostsContext context, IHistoryRule historyRule)
        {
            _context = context;
            _mapper = mapper;
            _postRepository = new Repository<Posts>(_context);
            _historyRule = historyRule;
        }

        public bool LikePost(int idPost, int idUser)
        {
            try
            {
                if (!_historyRule.HasLikedPost(idPost , idUser))
                {
                    var post = _postRepository.List(p => p.Id == idPost).FirstOrDefault();
                    post.Like = post.Like +1;
                    _postRepository.Update(post);
                    _historyRule.AddHistory(idPost, idUser);
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e.Message);
            }
            return false;
        }

        public List<PostDTO> ListAllPost()
        {
            try
            {
                var posts = _postRepository.ListAll();
                return _mapper.Map<IList<Posts>, List<PostDTO>>(posts);
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e.Message);
            }
        }

        public List<PostDTO> ListPaged(int pageCurrent, int quantityItems)
        {
            try
            {
                var posts = _postRepository.ListAll().Skip((pageCurrent - 1) * quantityItems).Take(quantityItems).ToList();
                return _mapper.Map<IList<Posts>, List<PostDTO>>(posts);
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e.Message);
            }
        }

        public int SavePost(PostDTO postDto)
        {
            try
            {
                var postEntity = _mapper.Map<PostDTO, Posts>(postDto);
                var post = _postRepository.Add(postEntity);
                return post.Id;
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e.Message);
            }
        }
    }
}
