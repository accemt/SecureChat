using SChat.Models.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SChat.Models
{
    public class SChatDBContext : DbContext
    {
        /*public SChatDBContext() : base()
        {
            Database.SetInitializer(
                new DropCreateDatabaseIfModelChanges<SChatDBContext>());
        }*/

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Chat> Chats { get; set; }
    }
}