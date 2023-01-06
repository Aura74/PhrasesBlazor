using Microsoft.EntityFrameworkCore;
using PhrasesBlazor.Data;

namespace PhrasesBlazor.Services
{
    public class PhrasesDbContext : DbContext
    {
        public PhrasesDbContext(DbContextOptions<PhrasesDbContext> options) : base(options)
        {

        }

        public DbSet<Phrases> Phrases { get; set; }
        public DbSet<Cultures> Cultures { get; set; }
        public DbSet<Data.Pages> Pages { get; set; }
        public DbSet<Applications> Applications { get; set; }
    }
}
