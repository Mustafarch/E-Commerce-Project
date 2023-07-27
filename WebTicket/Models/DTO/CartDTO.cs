namespace WebTicket.Models.DTO
{
	public class CartDTO
	{
		public int ID { get; set; }

        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public decimal ProductTotal { get; set; }

        public string ProductPicture { get; set; }
        public int ProductQuantity { get; set; }
    }
}
