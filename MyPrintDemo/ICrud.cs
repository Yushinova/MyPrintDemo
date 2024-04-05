using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPrintDemo
{
    public interface ICrud<T>
    {
        IEnumerable<T> GetAllAsync();
        T GetByIDAsync(int id);
        void InsertObjAsync(T obj);
        void UpdateObjAsync(T obj);
    }
}
