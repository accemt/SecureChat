using SChat.Models.Domain.ContentTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SChat.Models.Domain
{
    public class Message
    {
        [Key]
        public long Id { get; set; }
        public User Author { get; set; }
        public Chat ReceiverChat { get; set; }
        //public ReceiverType ReceiverType { get; set; }
        public Nullable<DateTime> Time { get; set; }
        public string MessageText { get; set; }
    }
}