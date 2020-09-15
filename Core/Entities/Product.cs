namespace Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public Brand Brand { get; set; }
        public int BrandId { get; set; }
        public Type Type { get; set; }
        public int TypeId { get; set; }
    }
}