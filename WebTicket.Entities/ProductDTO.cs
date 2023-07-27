using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTicket.Entities
{
    public class ProductDTO
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
        public string CategoryName { get; set; }
    }
}
