using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_006_A.Models
{
    public partial class Customer
    {
        public string IdCustomer { get; set; }
        public string Nama { get; set; }
        public string NoHp { get; set; }
        public string AlamatLengkap { get; set; }
        public string Username { get; set; }
        public string IdPemesanan { get; set; }
        public string IdPembayaran { get; set; }
        public string NoResi { get; set; }
        public string IdAlbum { get; set; }

        public virtual DetailAlbum IdAlbumNavigation { get; set; }
        public virtual Pembayaran IdPembayaranNavigation { get; set; }
        public virtual Pemesanan IdPemesananNavigation { get; set; }
        public virtual Pengiriman NoResiNavigation { get; set; }
        public virtual SignIn UsernameNavigation { get; set; }
    }
}
