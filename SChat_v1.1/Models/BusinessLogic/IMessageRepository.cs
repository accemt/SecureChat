using SChat.Models.Domain;
using SChat.Models.Domain.ContentTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SChat.Models.BusinessLogic
{
    interface IMessageRepository
    {
        OperationResult<Message> Add(Message NewMessage);
        OperationResult<Message> GetById(int ChatId, int MessageID);
        OperationResult<IEnumerable<Message>> GetAll(int ChatId, int LastCount = 15);
    }
}
