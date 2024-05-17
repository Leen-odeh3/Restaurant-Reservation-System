using System.Threading.Tasks;

namespace RestaurantReservation.Db.Abstracts
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
