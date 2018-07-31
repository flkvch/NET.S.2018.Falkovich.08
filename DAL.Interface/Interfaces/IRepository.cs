using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Interfaces
{
    /// <summary>
    /// Repository
    /// </summary>
    public interface IRepository<T>
    {
        void Create(T account);

        T GetBy(string id);

        void Update(T account);
        //CRUD operations Create Read Update Delete - wout delete?
    }
}
