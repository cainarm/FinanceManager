using System.Collections.Generic;


namespace Financeiro.Models
{
    public class Source
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<Expense> Expenses { get; set; }
    }
}