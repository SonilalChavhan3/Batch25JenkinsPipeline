namespace Batch25JenkinsPipeline.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public bool IsInStock { get; set; }


        public Product(int id, string name, decimal price, string category, bool isInStock = true)
        {
            Id = id;
            Name = name;
            Price = price;
            Category = category;
            IsInStock = isInStock;
        }
    }
}
