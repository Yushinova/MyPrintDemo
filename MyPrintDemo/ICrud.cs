using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPrintDemo
{
    public interface ICrud<T>
    {
       Task <IEnumerable<T>> GetAllAsync();
       Task <T> GetByIDAsync(int id);
        Task InsertObjAsync(T obj);
        Task UpdateObjAsync(T obj);
    }
}
