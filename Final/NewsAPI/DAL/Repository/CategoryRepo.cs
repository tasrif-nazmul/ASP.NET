using DAL.EF;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class CategoryRepo
    {
        public static List<Category> Get()
        {
            var db = new NewsContext();
            return db.Categories.ToList();
        }

        public static Category Get(int id)
        {
            var db = new NewsContext();
            var data = db.Categories.Find(id);
            return data;
        }

        public static bool Add(Category c)
        {
            var db = new NewsContext();
            db.Categories.Add(c);
            return db.SaveChanges() > 0;
        }

        public static bool Update(Category c)
        {
            var db = new NewsContext();
            db.Categories.AddOrUpdate(c);
            return db.SaveChanges() > 0;
        }

        public static bool delete(int id)
        {
            var db = new NewsContext();
            var data = db.Categories.Find(id);
            db.Categories.Remove(data);
            return db.SaveChanges() > 0;    
        }
    }
}
