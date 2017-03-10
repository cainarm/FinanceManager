using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financeiro.Models
{
    public class Expense
    {
        public int id { get; set; }
        public double value { get; set; }
        public DateTime  date { get; set; }
        public Source source { get; set; }
        public Classification classification { get; set; }
    }
}