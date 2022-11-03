using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace API_Web.Models
{
    public class BaiViett
    {
        [Required]
        [ForeignKey("IDNhomTin")]
        public int IDNhomTin { get; set; }
        [Required]
        [ForeignKey("IDTheLoai")]
        public int IDTheLoai { get; set; }
        [Required]
        [ForeignKey("IDQuangCao")]
        public int IDQuangCao { get; set; }
        public string TenBaiViet { get; set; }
        public string NoiDungBaiViet { get; set; }
        public string HinhAnh { get; set; }
        public double SoSaoTB { get; set; }
        public int LuotXem { get; set; }
        [Required]
        public DateTime NgayTao { get; set; }
        public string NguoiTao { get; set; }
        public DateTime NgaySua { get; set; }
        public string NguoiSua { get; set; }
    }
}
