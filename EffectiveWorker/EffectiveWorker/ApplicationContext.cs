using EffectiveWorker.model;
using Microsoft.EntityFrameworkCore;

namespace EffectiveWorker
{
    public sealed class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
            //Database.EnsureCreated();
        }

        public DbSet<Worker> Workers { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql
            ("Server=127.0.0.1;" +
             "Port=5432;" +
             "Database=dotnet;" +
             "User Id=postgres;" +
             "Password=mysecretpassword;");
        }
    }
}