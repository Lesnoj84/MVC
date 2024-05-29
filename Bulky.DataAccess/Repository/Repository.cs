using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;

namespace BulkyBook.DataAccess.Repository;


public class Repository<T> : IRepository<T> where T : class //Repository class impements IRepository and creates real mothods.
{

    ApplicationDbContext _db;

    internal DbSet<T> dbSet;
    public Repository(ApplicationDbContext db)
    {
        _db = db;
        dbSet = _db.Set<T>(); //Set is an method that is in-build in DdContext class to set T as a class.
        //_db.Products.Include(u => u.Category);
    }


    public void Add(T entity)
    {
        //_db.Add(entity);
        dbSet.Add(entity);
    }

    public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false)
    {
        IQueryable<T> query;
        if (tracked)
        {
            query = dbSet;

        }
        else
        {
            query = dbSet.AsNoTracking();
        }

        query = query.Where(filter);
        if (!string.IsNullOrEmpty(includeProperties))
        {
            foreach (var includeProp in includeProperties
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProp);
            }
        }
        return query.FirstOrDefault();

    }

    //Include can have multiple inputs like "Category,CoverType,ect" thats why we need to make comma seperator: necw char[]{','}.
    public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter, string? includeProperties = null)
    {
        IQueryable<T> query = dbSet;
        if (filter != null)
        {
            query = query.Where(filter);
        }
        if (!string.IsNullOrEmpty(includeProperties))
        {
            foreach (var includeProp in includeProperties
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProp);
            }
        }
        return query.ToList();
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
