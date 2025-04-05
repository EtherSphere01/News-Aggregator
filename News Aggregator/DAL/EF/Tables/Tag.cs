using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Tag
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual List<Article> Articles { get; set; }
        public Tag()
        {
            Articles = new List<Article>();
        }
    }
}
