using Core.Entities;

namespace Core.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<Product> ProductRepository { get; }
        IGenericRepository<Brand> BrandRepository { get; }
        IGenericRepository<Type> TypeRepository { get; }
    }
}