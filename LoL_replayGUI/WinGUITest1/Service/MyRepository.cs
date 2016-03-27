using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinGUITest1.Service
{
    class MyRepository<T> where T : BaseEntity
    {
        public List<T> Table = new List<T>();
        public T GetById(int id)
        {
            return Table.Where(r=>r.Id == id).FirstOrDefault();
        }
        public void Insert(T entity)
        {
            Table.Add(entity);
        }
        public void Update(T entity)
        {
            Table.Remove(entity);
            Table.Add(entity);
        }
        public void Delete(T entity)
        {
            Table.Remove(entity);
        }
    }
}
