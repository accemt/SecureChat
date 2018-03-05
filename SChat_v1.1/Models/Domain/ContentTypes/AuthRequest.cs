using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SChat.Models.Domain.ContentTypes
{

    public class AuthRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }

    /*public class AuthResult
    {
        public bool result { get; set; }
        public string Description { get; set; }
        public User UserInstance { get; set; }

        public AuthResult(bool _result, User _UserInstance = null, string _Desc = "")
        {
            result = _result;
            UserInstance = _UserInstance;
            Description = _Desc;
        }
    }*/
}