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
    public class HistoryRule : IHistoryRule
    {
        private readonly PostsContext _context;
        private readonly IMapper _mapper;
        private readonly Repository<History> _historyRepository;

        public HistoryRule(IMapper mapper, PostsContext context)
        {
            _context = context;
            _mapper = mapper;
            _historyRepository = new Repository<History>(_context);
        }

        public HistoryDTO List(int idHistory)
        {
            try
            {
                var history = _historyRepository.List(h => h.Id == idHistory).FirstOrDefault();
                return _mapper.Map<History, HistoryDTO>(history);
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e.Message);
            }
        }

        public List<HistoryDTO> ListAll()
        {
            try
            {
                var history = _historyRepository.ListAll();
                return _mapper.Map<IList<History>, List<HistoryDTO>>(history);
            }
            catch (Exception e)
            {
                throw new Exception("Erro: " + e.Message);
            }
        }

        public HistoryDTO ListByPost(int idPost)
        {
            try
            {
                var history = _historyRepository.List(h => h.PostID == idPost).FirstOrDefault();
                return _mapper.Map<History, HistoryDTO>(history);
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e.Message);
            }
        }

        public HistoryDTO ListByUSer(int idUser)
        {
            try
            {
                var history = _historyRepository.List(h => h.UserID == idUser).FirstOrDefault();
                return _mapper.Map<History, HistoryDTO>(history);
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e.Message);
            }
        }

        public bool HasLikedPost(int idPost , int idUser)
        {
            return _historyRepository.List(h => h.PostID == idPost && h.UserID == idUser).Any();
        }

        public void AddHistory(int idPost , int idUser)
        {
            try
            {
                var history = new History()
                {
                    PostID = idPost,
                    UserID = idUser,
                    DateRegistration = DateTime.Now
                };
                _historyRepository.Add(history);
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e.Message);
            }
        }
    }
}
