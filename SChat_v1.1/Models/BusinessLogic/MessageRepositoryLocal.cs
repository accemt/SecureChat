using SChat.Models.BusinessLogic;
using SChat.Models.CacheRepository;
using SChat.Models.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Caching;
using System.Web;

namespace SChat.Models.BusinessLogic
{
    public class MessageRepositoryLocal //: IMessageRepository
    {
        private static Dictionary<Chat, List<Message>> MessageList = new Dictionary<Chat, List<Message>>();

        public MessageRepositoryLocal()
        {
            Debug.WriteLine("!!!");
            if (MessageList.Count() == 0) {
                //var MesList = new List<Message>();
                GlobalCache.getIstance().Add("id", 777, DateTime.Now.AddSeconds(10));

                var chat = new Chat { Id = 0, Name = "Chat 1" };
                MessageList.Add(chat, new List<Message>());
                MessageList[chat].Add(new Message { Id = 1, Author = new User { }, MessageText = "TestBody 1" });
                MessageList[chat].Add(new Message { Id = 2, Author = new User { }, MessageText = "TestBody 2" });
                MessageList[chat].Add(new Message { Id = 3, Author = new User { }, MessageText = "TestBody 3" });
            }
        }

        public void Add(Message NewMessage) {
            if (!MessageList.ContainsKey(NewMessage.ReceiverChat))
                MessageList.Add(NewMessage.ReceiverChat, new List<Message>());
            MessageList[NewMessage.ReceiverChat].Add(NewMessage);
        }

        public Message GetById(Chat ChatID, int MessageID) {
            if (MessageList.ContainsKey(ChatID))
                return MessageList[ChatID].Find(x => x.Id == MessageID);
            else
                return null;
        }

        public IEnumerable<Message> GetAll(Chat ChatID, int LastCount = 15) {
            if (MessageList.ContainsKey(ChatID)) {
                if (GlobalCache.getIstance().Contains("id"))
                    MessageList[ChatID].First<Message>().Id = Convert.ToInt32(GlobalCache.getIstance().Get("id"));
                else
                    MessageList[ChatID].First<Message>().Id = 111;
                return MessageList[ChatID];
            }
            else
                return null;
        }
    }
}