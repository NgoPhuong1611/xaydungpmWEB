namespace Monthayhung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Dathang")]
    public partial class Dathang
    {
        [Key]
        [StringLength(10)]
        public string Madonhang { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime Ngaytao { get; set; }

        [Required]
        [StringLength(50)]
        public string Tinhtrang { get; set; }

        [Required]
        public string Ghichu { get; set; }

        public int Soluong { get; set; }

        [Required]
        [StringLength(10)]
        public string Matk { get; set; }

        [Required]
        [StringLength(10)]
        public string Masp { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime Ngaygiaodukien { get; set; }

        public virtual Sanpham Sanpham { get; set; }

        public virtual User User { get; set; }
    }
}
