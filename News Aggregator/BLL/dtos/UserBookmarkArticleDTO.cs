using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class UserBookmarkArticleDTO : UserDTO
    {
        public virtual List<BookmarkArticleDTO> BookmarkArticles { get; set; }
        public UserBookmarkArticleDTO()
        {
            BookmarkArticles = new List<BookmarkArticleDTO>();
        }
    }
}
