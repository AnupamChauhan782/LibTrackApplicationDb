using LibTrack.Models;
using Microsoft.EntityFrameworkCore;

namespace LibTrack.DbConnect
{
    public class Connection:DbContext
    {
        public Connection(DbContextOptions<Connection> opt):base(opt)
        {
            
        }
        public DbSet<User> User_tbles { get; set; }
        public DbSet<Book> Book_Tables { get; set; }
        public DbSet<Transaction> Transcation_Tbles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>()
                .Property(t => t.TotalRent)
                .HasColumnType("decimal(18,2)");

            // Specify relationships
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.User)
                .WithMany(u => u.Transactions)
                .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Book)
                .WithMany(b => b.Transactions)
                .HasForeignKey(t => t.BookId);
        }

    }
}
