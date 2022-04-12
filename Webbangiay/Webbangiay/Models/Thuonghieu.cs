namespace Webbangiay.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;
    [Table("Thuonghieu")]
    public partial class Thuonghieu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Thuonghieu()
        {
            Sanpham = new HashSet<Sanpham>();
            Logo = "~/Content/images/thuonghieu/nike.jpg";
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
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}
