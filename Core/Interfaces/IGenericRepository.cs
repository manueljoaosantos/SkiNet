using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
    }
}
