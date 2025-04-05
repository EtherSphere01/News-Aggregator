using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TagRepo : Repo, IRepo<Tag, int, bool>, ITagFeature
    {
        public bool Create(Tag obj)
        {
            db.Tags.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            db.Tags.Remove(db.Tags.Find(id));
            return db.SaveChanges() > 0;
        }

        public Tag duplicate(string name)
        {
            var tag = (from t in db.Tags
                      where t.Name == name
                      select t).FirstOrDefault();
            return tag;
        }

        public Tag Get(int id)
        {
           return db.Tags.Find(id);
        }

        public List<Tag> GetAll()
        {
            return db.Tags.ToList();
        }

        public bool Update(Tag obj)
        {
            var tag = db.Tags.Find(obj.Id);
            tag.Name = obj.Name;
            return db.SaveChanges() > 0;

        }

        public Tag isavailable(string name)
        {
            var value = (from t in db.Tags
                         where t.Name == name
                         select t).FirstOrDefault();
            return value;
        }

    }
}
