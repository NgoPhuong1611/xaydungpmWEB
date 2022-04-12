namespace Monthayhung.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            Dathang = new HashSet<Dathang>();
        }

        [Key]
        [StringLength(10)]
        public string Matk { get; set; }

        [StringLength(50)]
        public string Tentk { get; set; }

        public string Mk { get; set; }

        public string Diachi { get; set; }

        [StringLength(10)]
        public string SDT { get; set; }

        public string Email { get; set; }

        public bool? Gt { get; set; }

        public bool? Loaitk { get; set; }

        public string Avt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dathang> Dathang { get; set; }
    }
}
