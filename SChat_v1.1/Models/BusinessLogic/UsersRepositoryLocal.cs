using SChat.Models.Domain;
using SChat.Models.Domain.ContentTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SChat.Models.BusinessLogic
{
    public class UserRepositoryLocal : IUserRepository
    {
        private static List<User> UserList = new List<User>();

        public UserRepositoryLocal()
        {
            if (UserList.Count() == 0) {
                UserList.Add(new User { Id = 1, Name = "User1", PasswordHash = CryptoFunctions.CalcHash("123") });
                UserList.Add(new User { Id = 2, Name = "Test User 2" });
                UserList.Add(new User { Id = 3, Name = "Test User 3" });
            }
        }

        public AuthResponse Authorize(AuthRequest AReq)
        {
            User UserInstance = UserList.Find(x => x.Id == AReq.Id);

            if (UserInstance == null)
                UserInstance = UserList.Find(x => x.Name == AReq.Name);

            if (UserInstance == null)
                return new AuthResponse(false, null, "Entered user isn't found.");

            if (string.Compare(CryptoFunctions.CalcHash(AReq.Password), UserInstance.PasswordHash) != 0)
                return new AuthResponse(false, UserInstance.token, "Password isn't valid");

            UserInstance.token = CryptoFunctions.GenToken(UserInstance);

            return new AuthResponse(true, UserInstance.token);
        }

        public User getUser(int UserID) {
            var UserInstance = UserList.Find(x => x.Id == UserID);
            if (UserInstance == null)
                throw new Exception("No user is found.");
            return UserInstance;
        }

        public IEnumerable<User> getUsers() {
            return UserList;
        }

        public OperationResult<User> Add(User NewUser) {
            UserList.Add(NewUser);
            return new OperationResult<User>(true, null);
        }

        public User GetById(int UserID) {
            return UserList.Find(x => x.Id == UserID);
        }

        public IEnumerable<User> GetAll() {
            return UserList;
        }
    }
}