using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    internal class UserRepo : Repo, IUser<bool, User>
    {
        public bool Add(User obj)
        {
            db.Users.Add(obj);
            return db.SaveChanges() > 0;
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public bool Login(string Username, string Password)
        {
            var data = db.Users.FirstOrDefault(u=> u.Username == Username && u.Password == Password);
            if (data != null) return true;
            return false;
        }
    }
}
