using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTicket.Entities
{
    public class Kullanicilar
    {
       public int ID { get; set; }
        public string AdiSoyadi { get; set; }
        public string Kadi { get; set; }
        public string Sifre { get; set; }
    }
}
