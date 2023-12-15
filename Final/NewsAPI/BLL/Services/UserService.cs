using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService
    {
        public static bool Add(UserDTO u)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDTO, User>();
            });

            var mapper = new Mapper(config);
            var data = mapper.Map<User>(u);
            return DataAccessFactory.UserData().Add(data);
        }

        public static List<UserDTO> Get()
        {
            var data = DataAccessFactory.UserData().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
            });

            var mapper = new Mapper(config);
            return mapper.Map<List<UserDTO>>(data);
        }
    }
}
