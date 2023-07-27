namespace WebTicket.Entities
{
    public class Product
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductPicture { get; set; }
        public string ProductSize { get; set; }
        public string ProductColor { get; set; }
        public int ProductStok { get; set; }
        public int ProductQuantity { get; set; }
        public decimal ProductTotal { get; set; }
        public string ProductExplanation { get; set; }
        public int CategoryID { get; set; }
        

    }
}
