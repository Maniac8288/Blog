﻿using System.Collections.Generic;

namespace DataModel
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string dataBird { get; set; }
        public string Photo { get; set; }

        public string Salt { get; set; }
        public List<Role> Roles { get; set; }
    }
}