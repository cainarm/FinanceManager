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
    public class ClassificationRepository
    {
        private  Context db = new Context();

        public IEnumerable<Classification> getAll()
        {
            return db.classification.ToList();
        }
        public void create(Classification cl)
        {
            db.classification.Add(cl);
            db.SaveChanges();
        }
        public void edit(Classification cl)
        {
            db.Entry(cl).State = EntityState.Modified;
            db.SaveChanges();

        }
        public void delete(int id)
        {
            try
            {
                db.classification.Remove(getById(id));
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public Classification getById(int id)
        {
           return db.classification.Find(id);
        }
    }
}