using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorMVC_DataAccess.Repositories
{
    public interface IRepository<T1, T2> where T1 : class
    {
        IEnumerable<T1> GetAll();
        T1 GetByID(T2 id);
        T1 Insert(T1 entity);
        void Update(T1 entity);
        void Delete(T2 id);
        void Save();
    }
}
