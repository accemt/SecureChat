using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SChat.Models.Domain
{
    public class Chat : Receiver
    {
        //public Chat(int _id, List<User> LU) { MessageId = _id;  Users = LU; }
        //public int MessageId { get; set; }/
        public ICollection<User> Users { get; set; }
        public Chat() : base()
        {
            Users = new List<User>();
        }
    }
}