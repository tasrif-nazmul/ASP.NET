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
    public class PostService
    {
        public static List<PostDTO> Get()
        {
            var data = DataAccessFactory.PostData().Read();
            //create a configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Post, PostDTO>();
            });
            //create a mapper instance
            var mapper = new Mapper(config);
            var mapped = mapper.Map<List<PostDTO>>(data); // <ki format a mapp hove> , (k mapp hobe)
            return mapped;

        }
        public static PostDTO Get(int id)
        {
            var data = DataAccessFactory.PostData().Read(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Post, PostDTO>();
            });
            var mapper = new Mapper(config);
            var mapped = mapper.Map<PostDTO>(data);
            return mapped;
        } 
        public static PostCommentDTO GetComment(int id)
        {
            var data = DataAccessFactory.PostData().Read(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Post, PostCommentDTO>();
                cfg.CreateMap<Comment, CommentDTO>();  
                //cfg.CreateMap<User, UserDTO>();  //if we want to see which user posted
            });
            var mapper = new Mapper(config);
            return mapper.Map<PostCommentDTO>(data);
        }
        public static bool Delete(int id)
        {
            var data = DataAccessFactory.PostData().Delete(id);
            return data;
        }
    }
}
