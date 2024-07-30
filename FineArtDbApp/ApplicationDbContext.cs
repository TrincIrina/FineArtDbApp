using Microsoft.EntityFrameworkCore;

namespace FineArtDbApp
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Painting> Paintings { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionStr = @"Data Source=HOME\SQLEXPRESS;
                                     Initial Catalog=Fine_Art_db;
                                     Integrated Security=SSPI;
                                     TrustServerCertificate=True;
                                     Timeout=5;";
            optionsBuilder.UseSqlServer(connectionStr);
        }
    }
}

