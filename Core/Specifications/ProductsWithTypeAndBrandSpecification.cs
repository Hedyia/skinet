using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypeAndBrandSpecification : BaseSepcification<Product>
    {
        public ProductsWithTypeAndBrandSpecification()
        {
            Include(x => x.Type);
            Include(x => x.Brand);
        }
        public ProductsWithTypeAndBrandSpecification(int id) : base(x => x.Id == id)
        {
            Include(x => x.Type);
            Include(x => x.Brand);
        }
    }
}