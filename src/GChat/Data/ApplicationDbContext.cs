using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GChatAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder
                .Entity<UserChat>()
                .HasKey(uc => new { uc.ChatId, uc.UserId });

        }


        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Message> Messages { get; set; } = default!;
        public DbSet<Chat> Chats { get; set; } = default!;
        public DbSet<UserChat> UserChats { get; set; }
    }
}
