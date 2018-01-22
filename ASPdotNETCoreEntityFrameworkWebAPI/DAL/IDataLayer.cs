using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPdotNETCoreEntityFrameworkWebAPI.DAL
{
    interface IDataLayer<T> where T : class
    {
        void Create(T entity);
        T GetById(int id);
        void Update(int id, T entity);
        void Delete(int id);
        IEnumerable<T> GetAll();
    }
}
