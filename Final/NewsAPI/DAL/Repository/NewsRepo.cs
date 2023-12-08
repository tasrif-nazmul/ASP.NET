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
    public class NewsRepo
    {
        public static bool Add(News n)
        {
            var db = new NewsContext();
            db.Newses.Add(n);
            return db.SaveChanges() > 0;

        }

        public static List<News> Get()
        {
            var db = new NewsContext();
            return db.Newses.ToList();
        }

        public static News Get(int id)
        {
            var db = new NewsContext();
            return db.Newses.Find(id);
        }

        public static bool Update(News n)
        {
            var db = new NewsContext();
            db.Newses.AddOrUpdate(n);
            return db.SaveChanges() > 0;
        }
        
        public static bool Delete(int id)
        {
            var db = new NewsContext();
            var data = db.Newses.Find(id);
            db.Newses.Remove(data);
            return db.SaveChanges() > 0;
        }
    }
}
