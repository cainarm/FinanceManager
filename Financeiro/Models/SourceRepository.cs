using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Associations.Connections;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data.Entity;

namespace Financeiro.Models
{
    public class SourceRepository
    {
        Context db = new Context();

        public IEnumerable<Source> getAll()
        {
            return db.source.ToList();
        }
        public void create(Source sr)
        {
            db.source.Add(sr);
            db.SaveChanges();
        }
        public void edit(Source sr)
        {
            db.Entry(sr).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void delete(int id)
        {
            try
            {
                db.source.Remove(getById(id));
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }
        public Source getById(int id)
        {
            return db.source.Find(id);
        }
    }
}