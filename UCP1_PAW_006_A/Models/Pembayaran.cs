using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_006_A.Models
{
    public partial class Pembayaran
    {
        public Pembayaran()
        {
            Customers = new HashSet<Customer>();
        }

        public string IdPembayaran { get; set; }
        public DateTime? TanggalPembayaran { get; set; }
        public string JenisPembayaran { get; set; }
        public int? TotalHarga { get; set; }
        public byte[] BuktiPembayaran { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
