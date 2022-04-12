namespace Monthayhung.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Thuonghieu")]
    public partial class Thuonghieu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Thuonghieu()
        {
            Sanpham = new HashSet<Sanpham>();
        }

        [Key]
        [StringLength(10)]
        public string Mathuonghieu { get; set; }

        [StringLength(50)]
        public string Tenthuonghieu { get; set; }

        [StringLength(50)]
        public string Quocgia { get; set; }

        public string Mota { get; set; }

        public string Logo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sanpham> Sanpham { get; set; }
    }
}
