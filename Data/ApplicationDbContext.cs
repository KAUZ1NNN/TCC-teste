using Microsoft.EntityFrameworkCore;
using TCCteste2.Models;

namespace TCCteste2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Collaborator> Collaborators { get; set; } // Substitua "Collaborator" pelo nome da sua entidade
    }
}
