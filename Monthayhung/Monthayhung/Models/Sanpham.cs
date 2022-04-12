namespace Monthayhung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sanpham")]
    public partial class Sanpham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sanpham()
        {
            Dathangs = new HashSet<Dathang>();
        }

        [Key]
        [StringLength(10)]
        public string Masp { get; set; }

        [Required]
        [StringLength(50)]
        public string Tensp { get; set; }

        [Required]
        [StringLength(10)]
        public string Mathuonghieu { get; set; }

        [Column(TypeName = "money")]
        public decimal Gia { get; set; }

        [Required]
        public string Gioithieu { get; set; }

        [Required]
        public string Anhsp { get; set; }

        [Required]
        [StringLength(50)]
        public string Size { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dathang> Dathangs { get; set; }

        public virtual Thuonghieu Thuonghieu { get; set; }
    }
}
