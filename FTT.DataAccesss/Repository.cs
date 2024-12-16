namespace FTT.DataAccesss
{
    using FTT.DbDesign;
    using FTT.DbEntity;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public class Repository<T> : IRepository<T> where T : EntityIdentity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public T GetById(int id, bool includeChildren = false, params string[] children)
        {
            IQueryable<T> query = _dbSet;

            if (includeChildren)
            {
                foreach (var child in children)
                {
                    query = query.Include(child);
                }

                return query.SingleOrDefault(x => x.Id == id)!;
            }

            return _dbSet.Find(id)!;
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
