using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BookReading.EntityDataModel
{
    public partial class BookReadingContext : DbContext
    {
        public BookReadingContext()
            : base("name=BookReadingDBConnection")
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Invitation> Invitations { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
