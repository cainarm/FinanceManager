using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financeiro.Models
{
    public class Classification
    {
        public int id { get; set; }
        public string name { get; set; }

        public virtual IEnumerable<Expense> expenses { get; set; }
    }
}