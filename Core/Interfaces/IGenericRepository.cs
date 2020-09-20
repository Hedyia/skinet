using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetAsync(int id);
        Task<IReadOnlyList<T>> GetListAsync();

        Task<T> GetAsync(ISpecification<T> spec);
        Task<IReadOnlyList<T>> GetListAsync(ISpecification<T> spec);
    }
}