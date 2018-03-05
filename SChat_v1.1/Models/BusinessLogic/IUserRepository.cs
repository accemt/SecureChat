using SChat.Models.Domain;
using SChat.Models.Domain.ContentTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SChat.Models.BusinessLogic
{
    interface IUserRepository
    {
        AuthResponse Authorize(AuthRequest AReq);
        User getUser(int UserID);
        IEnumerable<User> getUsers();
        OperationResult Add(User NewUser);

    }
}
