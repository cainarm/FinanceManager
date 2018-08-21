using System.Collections.Generic;

namespace Financeiro.Models
{
    public class Classification
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<Expense> Expenses { get; set; }
    }
}