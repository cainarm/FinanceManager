using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Financeiro.Models
{
    public class Context : DbContext
    {
        public Context()
            : base("Context")
        {
        }
        public DbSet<Expense> expense { get; set; }
        public DbSet<Source> source { get; set; }
        public DbSet<Classification> classification { get; set; }
    }
}