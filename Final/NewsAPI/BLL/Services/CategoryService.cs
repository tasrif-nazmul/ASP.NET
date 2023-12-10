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
    public class CategoryService
    {
        public static List<CategoryDTO> Get()
        {
            var data = CategoryRepo.Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category, CategoryDTO>();
            });

            var mapper = new Mapper(config);
            return mapper.Map<List<CategoryDTO>>(data);
        }

        public static CategoryDTO Get(int id)
        {
            var data = CategoryRepo.Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category, CategoryDTO>();
            });

            var mapper = new Mapper(config);
            return mapper.Map<CategoryDTO>(data);
        }

        public static bool Add(CategoryDTO c)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryDTO, Category>();
            });

            var mapper = new Mapper(config);
            var data = mapper.Map<Category>(c);
            return CategoryRepo.Add(data);
        }

        public static bool Update(int id, CategoryDTO c)
        {
            var exdata = CategoryRepo.Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryDTO, Category>();
            });

            var mapper = new Mapper(config);
            mapper.Map<Category>(c);
            exdata.Name = c.Name;
            return CategoryRepo.Update(exdata);
        }


        public static bool Delete(int id)
        {
            return CategoryRepo.delete(id);
        }
    }
}
