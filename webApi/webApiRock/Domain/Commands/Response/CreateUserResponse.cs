﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApiRock.Domain.Commands.Response
{
    public class CreateUserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
    }
}
