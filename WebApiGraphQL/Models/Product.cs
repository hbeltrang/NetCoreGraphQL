namespace WebApiGraphQL.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string ProductCode { get; set; }

        public string ProductName { get; set; }

        public int Categoryid { get; set; }

        public double Price { get; set; }

        public double StockQty { get; set; }

        public Category Category { get; set; }

    }
}
