using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CommentRepo : Repo, IRepo<Comment, string, bool>
    {
        public bool Create(Comment obj)
        {
            db.Comments.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(string id)
        {
            var ex = Read(id);
            db.Comments.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Comment> Read()
        {
            return db.Comments.ToList();
        }

        public Comment Read(string id)
        {
            return db.Comments.Find(id);
        }

        public bool Update(Comment obj)
        {
            throw new NotImplementedException();
        }
    }
}
