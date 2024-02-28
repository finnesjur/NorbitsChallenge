using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NorbitsChallenge.Data;
using NorbitsChallenge.Models.Contracts;

namespace NorbitsChallenge.Models.Repo;

public class WorkshopRepository<T> : IWorkshopRepository<T> where T : class
{
    private readonly DataContext _db;
    
    public WorkshopRepository(DataContext db)
    {
        this._db = db;
    }
    
    public void Dispose()
    {
        _db.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _db.DisposeAsync();
    }

    public T? Get(int id)
    {
        return _db.Find<T>(id);
    }

    public async Task<T?> GetAsync(int id)
    {
        return await _db.FindAsync<T>(id);
    }
    
    public async Task AddAsync(T t)
    {
        await _db.Set<T>().AddAsync(t);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(T t)
    {
        _db.Set<T>().Update(t);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(T t)
    {
        _db.Set<T>().Remove(t);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateRangeAsync(IEnumerable<T> t)
    {
        _db.Set<T>().UpdateRange(t);
        await _db.SaveChangesAsync();    
    }

    public IQueryable<T> GetAll()
    {
        return _db.Set<T>();
    }
}