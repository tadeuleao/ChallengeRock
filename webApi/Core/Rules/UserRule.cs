using AutoMapper;
using Core.DB.Context;
using Core.DB.Entity;
using Core.Model;
using Core.Repository;
using Core.Rules.Exceptions;
using System.Linq;

namespace Core.Rules
{
    public class UserRule : IUserRule
    {
        private readonly PostsContext _context;
        private readonly IMapper _mapper;
        private readonly Repository<Users> _userRepository;

        public UserRule(IMapper mapper , PostsContext context)
        {
            _mapper = mapper;
            _context = context;
            _userRepository = new Repository<Users>(_context);
        }

        /// <summary>
        /// List user for login
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public UserDTO ListUser(string login, string password)
        {
            try
            {
                var user = _userRepository.List(u => u.Login.Equals(login) && u.Password.Equals(password)).FirstOrDefault();
                return _mapper.Map<Users,UserDTO>(user);
            }
            catch (UserException e)
            {
                throw new UserException("Fail: " + e.Message);
            }
        }

        public UserDTO AddUser(UserDTO dto)
        {
            try
            {
                var entity = _mapper.Map<UserDTO, Users>(dto);
                if (_userRepository.List(u => u.Login.Equals(dto.Login)).Any())
                {
                    return dto;
                }
                var user  = _userRepository.Add(entity);
                return _mapper.Map<Users, UserDTO>(user);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
