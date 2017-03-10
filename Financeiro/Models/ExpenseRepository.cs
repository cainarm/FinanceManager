using Associations.Connections;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web;

namespace Financeiro.Models
{
    public class ExpenseRepository
    {
        private Context db = new Context();
       

        public IEnumerable<Expense> getAll()
        {
            return db.expense.Include(s => s.source).Include(c => c.classification).ToList();
        }
        public Expense getById(int id)
        {
            return db.expense.Include(s => s.source).Include(c => c.classification).Where(i => i.id==id).FirstOrDefault();
        }
        public void create(Expense expense)
        {
            expense.source = db.source.Find(expense.source.id);
            expense.classification = db.classification.Find(expense.classification.id);

            db.expense.Add(expense);
            db.SaveChanges();

        }

      public void edit(Expense expense)
      {
            expense.source = db.source.Find(expense.source.id);
            expense.classification = db.classification.Find(expense.classification.id);

            db.Entry(expense).State = EntityState.Modified;
            db.SaveChanges();
        }
      public void delete(int id)
      {
            try
            {
                db.expense.Remove(getById(id));
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }
        public IEnumerable<Expense> getByDate(DateTime date)
        {
            return db.expense.Include(s => s.source).Include(c => c.classification).Where(d => d.date == date).ToList();
        }
        public IEnumerable<Expense> getByDateAndSource(int source, DateTime date)
        {
            return db.expense.Include(s => s.source).Include(c => c.classification).Where(d => d.date == date && d.source.id == source).ToList();
        }
    }
}