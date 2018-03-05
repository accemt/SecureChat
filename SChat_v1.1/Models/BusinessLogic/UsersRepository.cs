using SChat.Models.CacheRepository;
using SChat.Models.Domain;
using SChat.Models.Domain.ContentTypes;
using SChat.Models.Exceptions;
using SChat.Models.Global;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace SChat.Models.BusinessLogic
{
    public class UserRepository : IUserRepository
    {
        private SChatDBContext db = new SChatDBContext();

        public UserRepository() {
        }

        public AuthResponse Authorize(AuthRequest AReq)
        {
            User UserInstance = db.Users.Find(AReq.Id);

            if (UserInstance == null)
                UserInstance = db.Users.Where<User>(x => x.Name == AReq.Name).FirstOrDefault<User>();

            if (UserInstance == null)
                return new AuthResponse(false, null, "Entered user isn't found.");

            if (AReq.Password != null)
                return AuthorizeByPassword(UserInstance, AReq);
            else if (AReq.Token != null)
                return AuthorizeByToken(UserInstance, AReq);

            return new AuthResponse(false, null, "No authenticative data.");
        }

        private AuthResponse AuthorizeByPassword(User UserInstance, AuthRequest AReq)
        {
            if (string.Compare(CryptoFunctions.CalcHash(AReq.Password), UserInstance.PasswordHash) != 0)
                return new AuthResponse(false, null, "Password isn't valid");

            UserInstance.token = CryptoFunctions.GenToken(UserInstance);
            UserInstance.tokenExpiry = DateTime.Now.AddSeconds(GlobalSettings.TokenExpiryPeriod);

            if (GlobalCache.getIstance().Contains("TokenAuth" + UserInstance.Id.ToString()))
                GlobalCache.getIstance().Set("TokenAuth" + UserInstance.Id.ToString(), UserInstance, DateTime.Now.AddSeconds(GlobalSettings.TokenExpiryPeriod));
            else
                GlobalCache.getIstance().Add("TokenAuth" + UserInstance.Id.ToString(), UserInstance, DateTime.Now.AddSeconds(GlobalSettings.TokenExpiryPeriod));

            db.Entry(UserInstance).State = EntityState.Modified;
            db.SaveChanges();

            return new AuthResponse(true, UserInstance.token, "Success.");
        }

        private AuthResponse AuthorizeByToken(User UserInstance, AuthRequest AReq)
        {
            User UserInstanceValidate;

            if (GlobalCache.getIstance().Contains("TokenAuth" + UserInstance.Id.ToString()))
            {
                UserInstanceValidate = (User)GlobalCache.getIstance().Get("TokenAuth" + UserInstance.Id.ToString());
                if ((UserInstanceValidate.tokenExpiry >= DateTime.Now) && (UserInstanceValidate.token == AReq.Token))
                    return new AuthResponse(true);
            } else if ((UserInstance.token == AReq.Token) && (UserInstance.tokenExpiry >= DateTime.Now))
                return new AuthResponse(true);

            return new AuthResponse(false, null, "Invalid token.");
        }

        public User getUser(int UserID) {
            return db.Users.Find(UserID);
        }

        public IEnumerable<User> getUsers() {
            //db.Users.Add(new User { MessageId = 15, Name = "User21", PasswordHash = CryptoFunctions.CalcHash("123") });
            //db.Entry(u1).State = EntityState.Added;
            //db.SaveChanges();
            return db.Users.ToList<User>();
        }

        public OperationResult Add(User NewUser) {
            try {
                db.Users.Add(NewUser);
                db.SaveChanges();
            } catch (UserManagementException e) {
                return new OperationResult(false, "UserManagement exception: " + e.Description);
            } catch (Exception e) {
                return new OperationResult(false, "System exception: " + e.ToString());
            }
            return new OperationResult(true, "Success");
        }

    }
}