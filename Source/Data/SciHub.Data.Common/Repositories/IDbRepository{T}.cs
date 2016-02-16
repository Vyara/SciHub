namespace SciHub.Data.Common.Repositories
{
    using System.Linq;
    using Models;

    public interface IDbRepository<T> : IDbRepository<T, int>
        where T : BaseModel<int>
    {
    }

    public interface IDbRepository<T, in TKey>
        where T : BaseModel<TKey>
    {
        IQueryable<T> All();

        IQueryable<T> AllWithDeleted();

        T GetById(TKey id);

        void Update(T entity);

        void Add(T entity);

        void Delete(T entity);

        void Delete(TKey id);

        void HardDelete(T entity);

        T Attach(T entity);

        void Detach(T entity);

        void SaveChanges();
    }
}
