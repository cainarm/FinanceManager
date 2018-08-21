using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Financeiro.Models
{
    public class ClassificationRepository
    {
        private readonly Context _db = new Context();

        public IEnumerable<Classification> GetAll()
        {
            return _db.Classification.ToList();
        }
        public void Create(Classification cl)
        {
            _db.Classification.Add(cl);
            _db.SaveChanges();
        }
        public void Edit(Classification cl)
        {
            _db.Entry(cl).State = EntityState.Modified;
            _db.SaveChanges();

        }
        public void Delete(int id)
        {
            try
            {
                _db.Classification.Remove(GetById(id));
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public Classification GetById(int id)
        {
           return _db.Classification.Find(id);
        }
    }
}