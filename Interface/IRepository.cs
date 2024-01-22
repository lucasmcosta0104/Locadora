namespace Locadora.Interface
{
    public interface IRepository<T> where T : class
    {
        Task Add(T entity, CancellationToken cancellationToken);
        Task Update(T entity, CancellationToken cancellationToken);
        Task Delete(T entity, CancellationToken cancellationToken);
        Task<T> Find(int id, CancellationToken cancellationToken);    
        Task<ICollection<T>> All(CancellationToken cancellationToken);
        Task SaveChangesAsync(CancellationToken cancellationToken);
        IQueryable<T> Find();
    }
}
