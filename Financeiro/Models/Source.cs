using Associations.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Financeiro.Models
{
    public class Source
    {
        public int id { get; set; }
        public string name { get; set; }

        public virtual IEnumerable<Expense> expenses { get; set; }
    }
}