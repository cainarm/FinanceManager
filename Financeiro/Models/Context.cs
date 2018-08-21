using System.Data.Entity;

namespace Financeiro.Models
{
    public class Context : DbContext
    {
        public Context()
            : base("Context")
        {
        }
        public DbSet<Expense> Expense { get; set; }
        public DbSet<Source> Source { get; set; }
        public DbSet<Classification> Classification { get; set; }
    }
}