using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserShare
    {
        bool Share(ShareArticle share);
        bool DeleteShare(int id);
        List<ShareArticle> GetShares(int userid);
        List<ShareArticle> GetShareByPlatform(string platform, int userid);

    }
}
