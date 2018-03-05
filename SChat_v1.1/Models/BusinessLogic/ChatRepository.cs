using SChat.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SChat.Models.BusinessLogic
{
    public class ChatRepository
    {
        private static List<Chat> ChatList = new List<Chat>();
        private UserRepository UserRepositoryInstance = new UserRepository();

        public ChatRepository()
        {
            if (ChatList.Count() == 0) {
                ChatList.Add(new Chat { Id = 0, Users = new List<User> { UserRepositoryInstance.getUser(1), UserRepositoryInstance.getUser(2) } });
                ChatList.Add(new Chat { Id = 0, Users = new List<User> { UserRepositoryInstance.getUser(1), UserRepositoryInstance.getUser(3) } });
            }
        }

        public void Add(Chat NewChat) {
            ChatList.Add(NewChat);
        }

        public Chat GetById(int ChatID) {
            return ChatList.Find(x => x.Id == ChatID);
        }

        public IEnumerable<Chat> GetAll() {
            return ChatList;
        }
    }
}