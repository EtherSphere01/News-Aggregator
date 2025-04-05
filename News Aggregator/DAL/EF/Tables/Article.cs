using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Article
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content {  get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Tag { get; set; }

        [Required]
        public string Author { get; set; }

        public int Count { get; set; }

        [ForeignKey("Tg")]
        public int? TgId { get; set; }
        public virtual Tag Tg { get; set; }


    }
}
