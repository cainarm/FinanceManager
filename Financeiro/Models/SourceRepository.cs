using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Financeiro.Models
{
    public class SourceRepository
    {
	    readonly Context _db = new Context();

        public IEnumerable<Source> GetAll()
        {
            return _db.Source.ToList();
        }
        public void Create(Source sr)
        {
            _db.Source.Add(sr);
            _db.SaveChanges();
        }
        public void Edit(Source sr)
        {
            _db.Entry(sr).State = EntityState.Modified;
            _db.SaveChanges();
        }
        public void Delete(int id)
        {
            try
            {
                _db.Source.Remove(GetById(id));
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }
        public Source GetById(int id)
        {
            return _db.Source.Find(id);
        }
    }
}