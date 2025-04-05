using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ShareDTO
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public DateTime SharedDate { get; set; }
        public string Platform { get; set; }
    }
}
