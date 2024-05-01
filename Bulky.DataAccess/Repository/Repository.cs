using Bulky.DataAccess;
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository;

public class Repository<T> : IRepository<T> where T : class
{

    ApplicationDbContext _db;

    internal DbSet<T> dbSet;
    public Repository(ApplicationDbContext db)
    {
        _db = db;
        dbSet = _db.Set<T>();
    }

  
    public void Add(T entity)
    {
        //_db.Add(entity);
        dbSet.Add(entity);
    }

    public T Get(Expression<Func<T, bool>> filter)
    {
        IQueryable<T> values = dbSet.Where(filter);

        return values.FirstOrDefault();
    }

    public List<T> GetAll()
    {
        IQueryable<T> values = dbSet;

        return values.ToList();
    }

    public void Remove(T entity)
    {
        dbSet.Remove(entity);
    }

    public void RemoveAll(List<T> entities)
    {
        dbSet.RemoveRange(entities);
    }
}
