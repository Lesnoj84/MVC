using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
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

    public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
    {
        IQueryable<T> values = dbSet.Where(filter);
        
        if (!string.IsNullOrEmpty(includeProperties))
        {
            foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                values = values.Include(item);
            }
        }
        return  values.FirstOrDefault();
    }

    //Include can have multiple inputs like "Category,CoverType,ect" thats why we need to make comma seperator: necw char[]{','}.
    public IEnumerable<T> GetAll(string? includeProperties = null)
    {
        IQueryable<T> values = dbSet;
        if (!string.IsNullOrEmpty(includeProperties))
        {
            //values = values.Include(includeProperties);

            foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
               values = values.Include(item);
            }
        }

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
