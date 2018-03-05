using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using SChat.Models.Domain;
using System.Diagnostics;
using SChat.Models.Domain.ContentTypes;
using SChat.Models.BusinessLogic;

namespace SChat.Controllers
{
    //[Authorize]
    public class UserController : ApiController
    {
        private IUserRepository UserRepositoryInstance = new UserRepository();

        public UserController() {
        }

        [HttpPost]
        public HttpResponseMessage Auth([FromBody]AuthRequest AReq) {
            HttpResponseMessage response;
            if (AReq == null) {
                response = Request.CreateResponse<AuthResponse>(System.Net.HttpStatusCode.NoContent, new AuthResponse(false, null, "AReq Data isn't taken."));
                return response;
            }

            AuthResponse AResponse = UserRepositoryInstance.Authorize(AReq);

            if (AResponse.result == true)
                response = Request.CreateResponse<AuthResponse>(System.Net.HttpStatusCode.OK, AResponse);
            else
                response = Request.CreateResponse<AuthResponse>(System.Net.HttpStatusCode.Unauthorized, AResponse);

            return response;
        }

        [HttpGet]
        public HttpResponseMessage GetUsers() {
            HttpResponseMessage response = Request.CreateResponse<IEnumerable<User>>(System.Net.HttpStatusCode.OK, UserRepositoryInstance.getUsers());
            return response;
        }

        /*
        [HttpPost]
        public HttpResponseMessage SendMessage([FromBody]Message message) {
            messageRepository.Add(message);
            return Request.CreateResponse<OperationResult>(System.Net.HttpStatusCode.Created, new OperationResult(true, "Mesage is sent successfully."));
        }
        */
    }
}
