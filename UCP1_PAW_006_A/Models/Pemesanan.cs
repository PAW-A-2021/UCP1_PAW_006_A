using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_006_A.Models
{
    public partial class Pemesanan
    {
        public Pemesanan()
        {
            Customers = new HashSet<Customer>();
        }

        public string IdPemesanan { get; set; }
        public DateTime? TanggalPemesanan { get; set; }
        public int? TotalHarga { get; set; }
        public string JenisAlbum { get; set; }
        public int? JumlahAlbum { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
