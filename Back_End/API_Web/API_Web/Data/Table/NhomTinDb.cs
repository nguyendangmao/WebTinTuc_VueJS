using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Web.Data.Table
{
    [Table("NhomTin")]
    public class NhomTinDb
    {
        [Key]
        public int IDNhomTin { get; set; }
        [Required]
        public string TenNhomTin { get; set; }
        [Required]
        public int ThuTuHienThi { get; set; }
        [Required]
        public DateTime NgayTao { get; set; }
        [Required]
        public string NguoiTao { get; set; }
        public DateTime NgaySua { get; set; }
        public string NguoiSua { get; set; }

    }
}
