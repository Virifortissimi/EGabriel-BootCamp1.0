using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA_DataAccess;

namespace OA_Repository
{
    public interface IRepository<T> where T: BaseEntity
    {
        T Get(int id);
        IEnumerable<T> GetAll();    
    }
}
