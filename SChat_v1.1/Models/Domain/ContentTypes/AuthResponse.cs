using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SChat.Models.Domain.ContentTypes
{
    public class AuthResponse
    {
        public bool result { get; set; }
        public string Description { get; set; }
        public string Token { get; set; }
        public AuthResponse(bool _result, string _token = null, string _Desc = "")
        {
            result = _result;
            Token = _token;
            Description = _Desc;
        }
    }
}