using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ArticleService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Article, ArticleDTO>();
                cfg.CreateMap<ArticleDTO, Article>();
                cfg.CreateMap<Article, ArticleTagDTO>();
                cfg.CreateMap<ArticleTagDTO, Article>();
                cfg.CreateMap<Tag, TagDTO>();
                cfg.CreateMap<TagDTO, Tag>();

            });
            return new Mapper(config);
        }
        public string Create(ArticleDTO obj)
        {
            var repo = DataAccessFactory.ArticleData();
            obj.Date = DateTime.Now.Date;
            var tag = obj.Tag;
            var repo2 = DataAccessFactory.TagFeature();
            var isavailable = repo2.isavailable(tag);

            var convert = GetMapper().Map<Article>(obj);
            if (isavailable == null)
            {
                var tagobj = new TagDTO();
                tagobj.Name = tag;
                var tagrepo = DataAccessFactory.TagData();
                tagrepo.Create(GetMapper().Map<Tag>(tagobj));
                convert.Tag = tag;
                isavailable = repo2.isavailable(tag);
                convert.TgId = isavailable.Id;
            }
            else
            {
                convert.Tag = tag;
                convert.TgId = isavailable.Id;
            }
            var value = repo.Create(convert);
            if (value == true)
            {
                return "Article Created Successfully";
            }
            else
            {
                return "Article Creation Failed";
            }
        }

        public string Update(ArticleDTO obj)
        {
            var repo = DataAccessFactory.ArticleData();
            var value = repo.Update(GetMapper().Map<Article>(obj));
            if (value == true)
            {
                return "Article Updated Successfully";
            }
            else
            {
                return "Article Update Failed";
            }
        }

        public string Delete(int id)
        {
            var repo = DataAccessFactory.ArticleData();
            var value = repo.Delete(id);
            if (value == true)
            {
                return "Article Deleted Successfully";
            }
            else
            {
                return "Article Deletion Failed";
            }
        }

        public ArticleDTO Get(int id)
        {
            var repo = DataAccessFactory.ArticleData();
            return GetMapper().Map<ArticleDTO>(repo.Get(id));
        }

        public List<ArticleDTO> GetAll()
        {
            var repo = DataAccessFactory.ArticleData();
            return GetMapper().Map<List<ArticleDTO>>(repo.GetAll());
        }

        public void UpdateTrending(int id)
        {
            var repo = DataAccessFactory.ArticleFeature();
            repo.UpdateTrending(id);
        }
    }
}
