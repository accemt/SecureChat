namespace SChat.Migrations
{
    using Models;
    using Models.BusinessLogic;
    using Models.Domain;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SChat.Models.SChatDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SChat.Models.SChatDBContext context)
        {
            SChatDBContext db = new SChatDBContext();
            /*var u1 = new User { Id = 1, Name = "User1", PasswordHash = CryptoFunctions.CalcHash("123") };
            var u2 = new User { Id = 2, Name = "Test User 2", PasswordHash = CryptoFunctions.CalcHash("Password123")};
            var u3 = new User { Id = 3, Name = "Test User 3", PasswordHash = CryptoFunctions.CalcHash("Password123")};
            var ch1 = new Chat { Id = 1, Name = "Chat 1", Users = new List<User> { u1, u2, u3 } };
            var ch2 = new Chat { Id = 2, Name = "Chat 2", Users = new List<User> { u1, u3 } };

            db.Users.Add(u1); // new User { Id = 1, Name = "User1", PasswordHash = CryptoFunctions.CalcHash("123"), Contacts = new List<User>() { } });
            db.Users.Add(u2); // new User { Id = 2, Name = "Test User 2", PasswordHash = CryptoFunctions.CalcHash("Password123") });
            db.Users.Add(u3); // new User { Id = 3, Name = "Test User 3", PasswordHash = CryptoFunctions.CalcHash("qwerty1") });

            db.Chats.Add(ch1);
            db.Chats.Add(ch2);
            db.Chats.Add(new Chat { Id = 3, Name = "Chat 3", Users = new List<User> { u2, u3 } });

            db.Messages.Add(new Message { Id = 1, Author = u1, MessageText = "TestBody 1" }); 
            db.Messages.Add(new Message { Id = 2, Author = u1, MessageText = "TestBody 2" });
            db.Messages.Add(new Message { Id = 3, Author = u2, MessageText = "TestBody 3" });
            */
            db.SaveChanges();
            

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
