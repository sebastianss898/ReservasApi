namespace ReservasHotelApi.Repositories;

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

using ReservasHotelApi.Data;

public class Repository<T> where T : class
{
    protected readonly HotelContext _db;


    public Repository(HotelContext db)
    {
        _db = db;
    }

    public async Task<List<T>> GetAll() =>
    await _db.Set<T>().ToListAsync();

    public async Task<T?> GetById(int id) =>
        await _db.Set<T>().FindAsync(id);

    public async Task Add(T entity)
    {
        _db.Set<T>().Add(entity);
        await _db.SaveChangesAsync();
    }

    public async Task Delete(T entity)
    {
        _db.Set<T>().Remove(entity);
        await _db.SaveChangesAsync();
    }

     public async Task SaveChanges() =>
        await _db.SaveChangesAsync();

    public async Task<List<T>> GetAllWithInclude<TProperty>(
    Expression<Func<T, TProperty>> include)
    {
        return await _db.Set<T>()
        .Include(include)
        .ToListAsync();
    }


}