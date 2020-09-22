using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithFiltersForCountSpec : BaseSepcification<Product>
    {
        public ProductsWithFiltersForCountSpec(ProductParamsSpec productParams)
        : base
        (x => (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
              (!productParams.BrandId.HasValue || x.BrandId == productParams.BrandId) &&
              (!productParams.TypeId.HasValue || x.TypeId == productParams.TypeId)
        )
        {

        }
    }
}