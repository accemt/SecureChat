using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.Diagnostics;
using SChat.Models.Domain;
using SChat.Models.Domain.ContentTypes;
using SChat.Models.BusinessLogic;
using System.Runtime.Caching;

namespace SChat.Controllers
{
    //[Authorize]
    public class MessagesController : ApiController
    {
        private IMessageRepository messageRepository = new MessageRepository();

        public MessagesController() {
        }

        [HttpGet]
        public HttpResponseMessage GetMessage(int ChatID, int MessageID) {
            var MessageInstance = messageRepository.GetById(ChatID, MessageID).context;
            HttpResponseMessage response;

            if (MessageInstance != null)
                response = Request.CreateResponse<Message>(System.Net.HttpStatusCode.OK, MessageInstance);
            else
                response = Request.CreateResponse<OperationResult<Message>>(System.Net.HttpStatusCode.NoContent, new OperationResult<Message>(false, "No messages is taken."));

            return response;
        }

        [HttpGet]
        public HttpResponseMessage GetMessages(int ChatID) {
            var OpResult = messageRepository.GetAll(ChatID);
            HttpResponseMessage response;

            if (OpResult.result)
            {
                response = Request.CreateResponse<IEnumerable<Message>>(System.Net.HttpStatusCode.OK, OpResult.context);
                Debug.WriteLine("Message: " + OpResult.context.First<Message>().Author.Name);
            }
            else
                response = Request.CreateResponse<OperationResult<Message>>(System.Net.HttpStatusCode.NoContent, new OperationResult<Message>(false, "No messages is taken."));

            return response;
        }

        [HttpPost]
        public HttpResponseMessage SendMessage([FromBody]Message message) {
            //return book;
            /*db.Books.Add(book);
            db.SaveChanges();*/
            messageRepository.Add(message);
            return Request.CreateResponse<OperationResult<Message>>(System.Net.HttpStatusCode.Created, new OperationResult<Message>(true, "Mesage is sent successfully."));
        }

        /*
        public IEnumerable<Book> GetBooks()
        {
            return db.Books;
        }
         
        [HttpPut]
        public void EditBook(int id, [FromBody]Book book)
        {
            if (id == book.MessageId)
            {
                db.Entry(book).State = EntityState.Modified;

                db.SaveChanges();
            }
        }

        public void DeleteBook(int id)
        {
            Book book = db.Books.Find(id);
            if (book != null)
            {
                db.Books.Remove(book);
                db.SaveChanges();
            }
        }

        // GET api/values
        public IEnumerable<string> GetMessages()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }*/
    }
}
