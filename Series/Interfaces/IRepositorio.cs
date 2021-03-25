using System.Collections.Generic;
namespace Series.Interfaces
{
    public interface IRepositorio <T>
    {
        List<T> List();
        T ReturnPerId (int id);
        void Insert(T entidade);
        void Delete(int id);
        void Update(int id, T entidade);
        int NextId();
        
         
    }
}