using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual List<BookmarkArticle> BookmarkArticles { get; set; }
        public virtual List<ShareArticle> ShareArticles { get; set; }
        public User()
        {
            BookmarkArticles = new List<BookmarkArticle>();
            ShareArticles = new List<ShareArticle>();
        }
    }
}
