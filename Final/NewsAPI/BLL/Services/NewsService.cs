using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class NewsService
    {
        public static List<NewsDTO> Get()
        {
            var data = NewsRepo.Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<News, NewsDTO>();
            });

            var mapper = new Mapper(config);
            return mapper.Map<List<NewsDTO>>(data);
        }

        public static NewsDTO Get(int id)
        {
            var data = NewsRepo.Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<News, NewsDTO>();
            });

            var mapper = new Mapper(config);
            return mapper.Map<NewsDTO>(data);
        }

        public static bool Add(NewsDTO n)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<NewsDTO, News>();
            });

            var mapper = new Mapper(config);
            var data = mapper.Map<News>(n);
            return NewsRepo.Add(data);
        }

        public static bool Update(int id, NewsDTO n)
        {
            var exdata = NewsRepo.Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<NewsDTO, News>();
            });
            var mapper = new Mapper(config);
            mapper.Map<News>(n);
            exdata.Name = n.Name;
            return NewsRepo.Update(exdata);
        }

        public static bool Delete(int id)
        {
            return NewsRepo.Delete(id);
            
        }
    }
}
