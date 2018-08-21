using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Financeiro.Models
{
    public class ExpenseRepository
    {
        private readonly Context _db = new Context();
       

        public IEnumerable<Expense> GetAll()
        {
            return _db.Expense.Include(s => s.Source).Include(c => c.Classification).ToList();
        }
        public Expense GetById(int id)
        {
            return _db.Expense.Include(s => s.Source).Include(c => c.Classification).Where(i => i.Id==id).FirstOrDefault();
        }
        public void Create(Expense expense)
        {
            expense.Source = _db.Source.Find(expense.Source.Id);
            expense.Classification = _db.Classification.Find(expense.Classification.Id);

            _db.Expense.Add(expense);
            _db.SaveChanges();

        }

      public void Edit(Expense expense)
      {
            expense.Source = _db.Source.Find(expense.Source.Id);
            expense.Classification = _db.Classification.Find(expense.Classification.Id);

            _db.Entry(expense).State = EntityState.Modified;
            _db.SaveChanges();
        }
      public void Delete(int id)
      {
            try
            {
                _db.Expense.Remove(GetById(id));
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }
        public IEnumerable<Expense> GetByDate(DateTime date)
        {
            return _db.Expense.Include(s => s.Source).Include(c => c.Classification).Where(d => d.Date == date).ToList();
        }
        public IEnumerable<Expense> GetByDateAndSource(int source, DateTime date)
        {
            return _db.Expense.Include(s => s.Source).Include(c => c.Classification).Where(d => d.Date == date && d.Source.Id == source).ToList();
        }
    }
}