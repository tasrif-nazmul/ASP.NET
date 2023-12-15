using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUser<RET,CLASS>
    {
        RET Add(CLASS obj);
        RET Login(string Username, string Password);
        List<CLASS> Get();
    }
}
