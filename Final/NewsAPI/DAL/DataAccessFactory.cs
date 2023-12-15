using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Category, int, bool> CategoryData()
        {
            return new CategoryRepo();
        }
        
        public static IRepo<News, int, bool> NewsData()
        {
            return new NewsRepo();
        }

        public static IUser<bool, User> UserData()
        {
            return new UserRepo();
        }
    }
}
