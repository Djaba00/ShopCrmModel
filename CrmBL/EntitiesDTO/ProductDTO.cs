namespace ShopCRM.DAL.Entities
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public virtual ICollection<SellDTO> Sells { get; set; }
    }
}
