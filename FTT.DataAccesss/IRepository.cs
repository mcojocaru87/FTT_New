namespace FTT.DataAccesss
{
    using FTT.DbEntity;
    using System;
    using System.Linq.Expressions;

    public interface IRepository<T> where T : EntityIdentity
    {
        IQueryable<T> GetAll();
        T GetById(int id, bool includeChildren = false, params string[] children);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        void Commit();
    }
}
