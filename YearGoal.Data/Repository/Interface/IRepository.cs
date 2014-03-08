using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YearGoal.Data.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        T GetById(string Id);
        bool Update(T newDocument, string Id);
        void Remove(string Id);
        
    }
}
