using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService
    {
        public static TokenDTO Authenticate(string uname, string password)
        {
            var result = DataAccessFactory.AuthData().Authenticate(uname, password);
            if(result)
            {
                var token = new Token();
                token.UserId = uname;
                token.CreateAt = DateTime.Now;
                token.Tkey = Guid.NewGuid().ToString();
                var ret = DataAccessFactory.TokenData().Create(token);
                if(ret != null)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<Token, TokenDTO>();
                    });
                    var mapper = new Mapper(config);
                    return mapper.Map<TokenDTO>(ret);
                }
            }
            return null;    
        }

        public static bool IsTokenValid(string tkey)
        {
            var extk = DataAccessFactory.TokenData().Read(tkey);
            if(extk != null && extk.DeletedAt == null) 
            {
                return true;
            }
            return false;
        }

        public static bool Logout(string tkey)
        {
            var extk = DataAccessFactory.TokenData().Read(tkey);
            extk.DeletedAt = DateTime.Now;
            var ud = DataAccessFactory.TokenData().Update(extk);
            if( ud != null )
            {
                return true;
            }
            return false;
        }
    }
}
