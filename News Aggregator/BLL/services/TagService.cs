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
    public class TagService
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
                cfg.CreateMap<Tag, TagArticleDTO>();
                cfg.CreateMap<TagArticleDTO, Tag>();

            });
            return new Mapper(config);
        }

        public string Create(TagDTO obj)
        {   var repo1 = DataAccessFactory.TagFeature();
            var check = repo1.duplicate(obj.Name);
            if(check != null)
            {
                return "Tag Already Exists";
            }

            var repo = DataAccessFactory.TagData();
            var value = repo.Create(GetMapper().Map<Tag>(obj));
            if (value == true)
            {
                return "Tag Created Successfully";
            }
            else
            {
                return "Tag Creation Failed";
            }
        }

        public string Update(TagDTO obj)
        {
            var repo = DataAccessFactory.TagData();
            var value = repo.Update(GetMapper().Map<Tag>(obj));
            if (value == true)
            {
                var repo1 = DataAccessFactory.ArticleFeature();
                var repo2 = DataAccessFactory.ArticleData();
                var articles = repo1.UpdateTag(obj.Id);
                if (articles != null)
                {
                    foreach (var article in articles)
                    {
                        article.Tag = obj.Name;
                        repo2.Update(article);
                    }
                }

                return "Tag Updated Successfully";
            }
            else
            {
                return "Tag Update Failed";
            }
        }

        public string Delete(int id)
        {
            var repo = DataAccessFactory.TagData();
            var value = repo.Delete(id);
            if (value == true)
            {
                var repo1 = DataAccessFactory.ArticleFeature();
                var repo2 = DataAccessFactory.ArticleData();
                var articles = repo1.UpdateTag(id);
                if(articles != null)
                {
                    foreach (var article in articles)
                    {
                        article.Tag = "Untagged";
                        article.TgId = 0;
                        repo2.Update(article);
                    }
                }

                return "Tag Deleted Successfully";
            }
            else
            {
                return "Tag Deletion Failed";
            }
        }

        public TagDTO Get(int id)
        {
            var repo = DataAccessFactory.TagData();
            return GetMapper().Map<TagDTO>(repo.Get(id));
        }

        public List<TagDTO> GetAll()
        {
            var repo = DataAccessFactory.TagData();
            var tags = repo.GetAll();
            return GetMapper().Map<List<TagDTO>>(tags);
        }

    }
}
