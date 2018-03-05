using SChat.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SChat.Models.BusinessLogic
{
    interface IMessageRepository
    {
        void Add(Message NewMessage);
        Message GetById(Chat ChatId, int MessageID);
        IEnumerable<Message> GetAll(Chat ChatId);
    }
}
