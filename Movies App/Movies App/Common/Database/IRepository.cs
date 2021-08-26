using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace Movies_App.Common.Database
{
    public interface IRepository<T> where T : IDatabaseItem, new()
    {
        Task<T> GetById(int id);
        Task<int> DeleteAsync(T item);
        Task<List<T>> GetAllAsync();
        Task<int> SaveAsync(T item);
    }
}
