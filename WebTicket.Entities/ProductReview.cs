﻿namespace WebTicket.Entities
{
	public class ProductReview
	{
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string Review { get; set; }
        public string NameSurname { get; set; }
        public string Mail { get; set; }
        public string Picture { get; set; }
        public DateTime Date { get; set; }
    }
}
