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
    internal class NewsRepo : Repo, IRepo<News, int, bool>
    {
        public bool Add(News obj)
        {
            db.Newses.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var data = db.Newses.Find(id);
            db.Newses.Remove(data);
            return db.SaveChanges() > 0;
        }

        public List<News> Get()
        {
            return db.Newses.ToList();
        }

        public News Get(int id)
        {
            return db.Newses.Find(id);
        }

        public bool Update(News obj)
        {
            db.Newses.AddOrUpdate(obj);
            return db.SaveChanges() > 0;
        }
    }
}
