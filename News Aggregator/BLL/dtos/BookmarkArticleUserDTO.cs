using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class BookmarkArticleUserDTO : BookmarkArticleDTO
    {
        public virtual UserDTO User { get; set; }
    }
}
