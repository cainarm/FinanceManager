using System;

namespace Financeiro.Models
{
	public class Expense
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public DateTime  Date { get; set; }
        public Source Source { get; set; }
        public Classification Classification { get; set; }
    }
}