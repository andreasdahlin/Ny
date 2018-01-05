using AMPDejtingsajt.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace AMPDejtingsajt.Repositories
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DataContext")
        {

        }

        public DbSet<Person> User { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<FriendRequest> FriendRequest { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<FriendRequest>()
                    .HasRequired(m => m.Sender)
                    .WithMany(t => t.FriendRequestSend)
                    .HasForeignKey(m => m.SenderId)
                    .WillCascadeOnDelete(false);

            modelBuilder.Entity<FriendRequest>()
                        .HasRequired(m => m.Receiver)
                        .WithMany(t => t.FriendRequestReceive)
                        .HasForeignKey(m => m.ReceiverId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Message>()
                        .HasRequired(m => m.Reciever)
                        .WithMany(t => t.MessageRecieve)
                        .HasForeignKey(m => m.RecieverId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Message>()
                        .HasRequired(m => m.Sender)
                        .WithMany(t => t.MessageSend)
                        .HasForeignKey(m => m.SenderId)
                        .WillCascadeOnDelete(false);

        }

    }
}