using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace New.Repositories
{
    public interface IAllRepo<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Get();
        T GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        //int GetNewInt(T obj, object id);
        //void Save();
    }
}
