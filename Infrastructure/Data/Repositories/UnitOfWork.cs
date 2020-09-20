using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(
            IGenericRepository<Product> productRepository,
            IGenericRepository<Brand> brandRepository,
            IGenericRepository<Type> typeRepository
            )
        {
            ProductRepository = productRepository;
            BrandRepository = brandRepository;
            TypeRepository = typeRepository;
        }
        public IGenericRepository<Product> ProductRepository { get; }

        public IGenericRepository<Brand> BrandRepository { get; }

        public IGenericRepository<Type> TypeRepository { get; }
    }
}