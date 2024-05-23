namespace FTT.DataAccesss
{
    using System;
    using System.Linq.Expressions;

    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        void Commit();
    }
}
