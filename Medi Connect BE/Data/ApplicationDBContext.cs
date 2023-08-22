using Medi_Connect_BE.Data;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_web_api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options) {}

        public DbSet<UserDetails>? UserDetails { get; set;}

        
    }
}
