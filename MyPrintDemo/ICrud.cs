using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPrintDemo
{
    interface ICrud<T>
    {
        IEnumerable<T> GetAll();
        T GetByID(int id);
        void InsertObj(T obj);
        void UpdateObj(T obj);
    }
}
