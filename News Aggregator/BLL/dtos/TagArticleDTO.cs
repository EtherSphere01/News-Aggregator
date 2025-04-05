using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TagArticleDTO : TagDTO
    {
        public List<ArticleDTO> Articles { get; set; }
        public TagArticleDTO()
        {
            Articles = new List<ArticleDTO>();
        }
    }
}
