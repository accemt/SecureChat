using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SChat.Models.Domain
{
    public class User : Receiver
    {
        public string PasswordHash { get; set; }
        public string token { get; set; }
        public System.Nullable<DateTime> tokenExpiry { get; set; }
        public ICollection<Chat> Chats { get; set; }

        public User() : base()
        {
            Chats = new List<Chat>();
        }
    }
}