using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class UserShareDTO : UserDTO
    {
        public virtual List<ShareDTO> Shares { get; set; }
        public UserShareDTO()
        {
            Shares = new List<ShareDTO>();
        }
    }
}
