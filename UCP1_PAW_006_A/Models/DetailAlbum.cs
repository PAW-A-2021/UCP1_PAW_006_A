using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_006_A.Models
{
    public partial class DetailAlbum
    {
        public DetailAlbum()
        {
            Customers = new HashSet<Customer>();
        }

        public string IdAlbum { get; set; }
        public string JenisAlbum { get; set; }
        public int? HargaAlbum { get; set; }
        public int? PajakAlbum { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
