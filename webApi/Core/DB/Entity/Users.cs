﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DB.Entity
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime DateRegistration { get; set; }
    }
}
