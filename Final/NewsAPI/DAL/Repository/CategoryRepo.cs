using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    internal class CategoryRepo : Repo, IRepo<Category, int, bool>
    {
        public bool Add(Category obj)
        {
            db.Categories.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var data = db.Categories.Find(id);
            db.Categories.Remove(data);
            return db.SaveChanges() > 0;    
        }

        public List<Category> Get()
        {
            return db.Categories.ToList();

        }

        public Category Get(int id)
        {
            var data = db.Categories.Find(id);
            return data;
        }

        public bool Update(Category obj)
        {
            //var data = Get(obj.Id);
            //db.Entry(data).CurrentValues.SetValues(obj);
            db.Categories.AddOrUpdate(obj);
            return db.SaveChanges() > 0;
        }
    }
}