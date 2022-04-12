namespace Webbangiay.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            Dathang = new HashSet<Dathang>();
            Avt = "~/Content/images/avatar/1.jpg";
        }

        [Key]
        [StringLength(10)]
        public string Matk { get; set; }

        [StringLength(50)]
        public string Tentk { get; set; }

        [Required(ErrorMessage = "M?t kh?u b?t bu?c nh?p")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=(.*[a-z]){1,})(?=(.*[\d]){1,})(?=(.*[\W]){1,})(?!.*\s).{8,}$")]
        [StringLength(maximumLength: 20, MinimumLength = 8, ErrorMessage = "?? dài m?t kh?u t? 8-20 kí t?")]
        [Display(Name = "M?t kh?u:")]
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
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}
