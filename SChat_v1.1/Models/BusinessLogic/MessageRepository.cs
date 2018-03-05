using SChat.Models.BusinessLogic;
using SChat.Models.CacheRepository;
using SChat.Models.Domain;
using SChat.Models.Domain.ContentTypes;
using SChat.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Caching;
using System.Web;

namespace SChat.Models.BusinessLogic
{
    public class MessageRepository : IMessageRepository
    {
        private SChatDBContext db;

        public MessageRepository()
        {
            db = new SChatDBContext();
            Debug.WriteLine("!!!");
        }

        public OperationResult<Message> Add(Message NewMessage) {
            try
            {
                db.Messages.Add(NewMessage);
                db.SaveChanges();
            }
            catch (MessageException e)
            {
                return new OperationResult<Message>(false, "Message exception exception: " + e.Description);
            }
            catch (Exception e)
            {
                return new OperationResult<Message>(false, "System exception: " + e.ToString());
            }
            return new OperationResult<Message>(true, "Success");
        }

        public OperationResult<Message> GetById(Chat ChatID, int MessageID) {
            Message MessageInstance = db.Messages.Where<Message>(x => x.ReceiverChat == ChatID).FirstOrDefault<Message>();
            if (MessageInstance == null)
                return new OperationResult<Message>(false, "Chat isn't found.");

            MessageInstance = db.Messages.Find(MessageID);
            return new OperationResult<Message>(true, "Success", MessageInstance);
        }

        public IEnumerable<Message> GetAll(int ChatID, int LastCount = 15) {
            IEnumerable<Message> MessageList = db.Messages.Include("Author").Include("ReceiverChat").Where<Message>(x => x.ReceiverChat.Id == ChatID);
            //db.Entry(MessageList.FirstOrDefault<Message>()).Reference("Author");
            /*foreach (var m in MessageList)
                db.Entry(m).Reference("Author").Load();
                */
            if (MessageList == null)
                return null;
            return MessageList;

            /*
            if (MessageList.ContainsKey(ChatID)) {
                if (GlobalCache.getIstance().Contains("id"))
                    MessageList[ChatID].First<Message>().Id = Convert.ToInt32(GlobalCache.getIstance().Get("id"));
                else
                    MessageList[ChatID].First<Message>().Id = 111;
                return MessageList[ChatID];
            }
            else
                return null;*/
        }
    }
}