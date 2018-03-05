using SChat.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SChat.Models.Exceptions
{
    public class UserManagementException : Exception
    {
        public string Description { get; set; }
        public User UserInstance { get; set; }
    }
}