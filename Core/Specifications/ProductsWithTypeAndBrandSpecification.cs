using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypeAndBrandSpecification : BaseSepcification<Product>
    {
        public ProductsWithTypeAndBrandSpecification(ProductParamsSpec productParams)
        : base
        (x => (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
              (!productParams.BrandId.HasValue || x.BrandId == productParams.BrandId) &&
              (!productParams.TypeId.HasValue || x.TypeId == productParams.TypeId)
        )
        {
            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;

                    case "priceDesc":
                        AddOrderByDesc(p => p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
            else
                AddOrderBy(n => n.Name);

            Include(x => x.Type);
            Include(x => x.Brand);
            var skip = (productParams.PageSize * (productParams.PageIndex - 1));
            ApplyPaging(skip, take: productParams.PageSize);
        }
        public ProductsWithTypeAndBrandSpecification(int id) : base(x => x.Id == id)
        {
            Include(x => x.Type);
            Include(x => x.Brand);
        }
    }
}