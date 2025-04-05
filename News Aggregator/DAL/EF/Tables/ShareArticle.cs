using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class ShareArticle
    {
        public int Id { get; set; }

        [Required]
        public int ArticleId { get; set; }
        public DateTime SharedDate { get; set; }
        [Required]
        public string Platform { get; set; }

        [ForeignKey("Uname")]
        public int UserId { get; set; }
        public virtual User Uname { get; set; }

    }
}
