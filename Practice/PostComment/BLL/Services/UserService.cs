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
    public class UserService
    {
        public static List<UserDTO> Get()
        {
            var data = DataAccessFactory.UserData().Read();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<UserDTO>>(data);

        }

        public static UserDTO Get(string uname)
        {
            var data = DataAccessFactory.UserData().Read(uname);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<UserDTO>(data);
        }

        public static UserPostDTO GetPost(string uname)
        {
            var data = DataAccessFactory.UserData().Read(uname);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserPostDTO>();
                cfg.CreateMap<Post, PostDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<UserPostDTO>(data);
        }
    }
}
