using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTicket.Entities
{
    public class Satilanlar
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }

        public decimal ProductTotal { get; set; }
        public int SiparisID { get; set; }
    }
}
