namespace Monthayhung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Dathangs = new HashSet<Dathang>();
            Avt = "~/Content/assets/images/BenhQuanOk.PNG";
        }

        [Key]
        [StringLength(10)]
        public string Matk { get; set; }

        [StringLength(50)]
        [Display(Name = "Tài khoản:")]
        [Required(ErrorMessage = "Tên tài khoản bắt buộc nhập")]
        public string Tentk { get; set; }

        [Required(ErrorMessage = "Mật khẩu bắt buộc nhập")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=(.*[a-z]){1,})(?=(.*[\d]){1,})(?=(.*[\W]){1,})(?!.*\s).{8,20}$")]
        [StringLength(maximumLength: 20, MinimumLength = 8, ErrorMessage = "Độ dài mật khẩu từ 8-20 kí tự")]
        [Display(Name = "Mật khẩu:")]
        public string Mk { get; set; }

        [Display(Name = "Địa chỉ:")]
        public string Diachi { get; set; }

        [StringLength(10)]
        [Display(Name = "Điện thoại:")]
        [Required(ErrorMessage = "Điện thoại bắt buộc nhập")]
        public string SDT { get; set; }

        [Display(Name = "Email:")]
        [Required(ErrorMessage = "Email bắt buộc nhập")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail sai định dạng")]
        public string Email { get; set; }

        [Display(Name = "Giới tính:")]
        public bool? Gt { get; set; }

        [Display(Name = "Loại tài khoản:")]
        public bool? Loaitk { get; set; }

        [Display(Name = "Avatar:")]
        public string Avt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dathang> Dathangs { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}
