using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPrintDemo
{
    interface ICrud<T>
    {
       Task <IEnumerable<T>> GetAllAsync();
       Task <T> GetByIDAsync(int id);
        Task InsertObj(T obj);
        Task UpdateObj(T obj);
    }
}
