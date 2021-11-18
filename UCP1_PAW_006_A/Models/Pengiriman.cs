using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_006_A.Models
{
    public partial class Pengiriman
    {
        public Pengiriman()
        {
            Customers = new HashSet<Customer>();
        }

        public string NoResi { get; set; }
        public string IdPembayaran { get; set; }
        public string StatusPengiriman { get; set; }
        public string JenisPengiriman { get; set; }
        public string AlamatLengkap { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
