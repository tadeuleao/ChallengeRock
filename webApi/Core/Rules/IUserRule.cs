using Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Rules
{
    public interface IUserRule
    {
        UserDTO ListUser(string login, string password);
    }
}
