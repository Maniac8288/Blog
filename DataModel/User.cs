using DataModel.Models;
using System;
using System.Collections.Generic;

namespace DataModel
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime Datebirth { get; set; }
        public string Photo { get; set; }
        public string Salt { get; set; }
        public string Email { get; set; }
        public DateTime LastVisit { get; set; }
        public DateTime DateRegister { get; set;}
        public List<Role> Roles { get; set; }
        public List<Post> Posts { get; set; }
        public CheckEmail CheckEmail { get; set; }
        public bool Status { get; set; }

    }
}