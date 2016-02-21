namespace SciHub.Data.Common.Repositories
{
    using System;
    using System.Linq;
    using Models;

    public interface IDbRepository<T>
        where T : class, IDeletableEntity, IAuditInfo
    {
        IQueryable<T> All();

        IQueryable<T> AllWithDeleted();

        T GetById(object id);

        void Update(T entity);

        void Add(T entity);

        void Delete(T entity);

        void HardDelete(T entity);

        T Attach(T entity);

        void Detach(T entity);

        void SaveChanges();
    }
}
