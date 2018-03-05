using SChat.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SChat.Models.Exceptions
{
    public class MessageException : Exception
    {
        public string Description { get; set; }
        public Message MessageInstance { get; set; }
    }
}