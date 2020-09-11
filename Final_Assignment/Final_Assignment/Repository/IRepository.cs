using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryCodeFirst.Repository
{
    interface IRepository<T> where T:class
    {
        List<T> GetAll();
        T GetById(int id);

        void Insert(T entity);
        void Delete(int id);

        void Edit(T entity);

       


    }
}
