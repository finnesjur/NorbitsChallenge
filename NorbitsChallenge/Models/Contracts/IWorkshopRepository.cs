using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorbitsChallenge.Models.Contracts;

public interface IWorkshopRepository<T> : IDisposable, IAsyncDisposable
{
        T Get(int id);
        Task<T> GetAsync(int id);
        Task AddAsync(T obj);
        IQueryable<T> GetAll();
        Task UpdateAsync(T t);
        Task UpdateRangeAsync(IEnumerable<T> t);
        Task DeleteAsync(T t);

}