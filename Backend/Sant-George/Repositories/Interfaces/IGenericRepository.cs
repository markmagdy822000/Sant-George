namespace Sant_George.Repositories.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<ICollection<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity, int id);
        Task DeleteAsync(int id);

    }
}
