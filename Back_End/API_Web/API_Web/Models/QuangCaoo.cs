using MediaBrowser.Model.Attributes;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace API_Web.Models
{
    public class QuangCaoo
    {
        [Required]
        [ForeignKey("NhaQuangCao")]
        public int IDNQC { get; set; }
        public string NoiDungQC { get; set; }
        public string TienQC { get; set; }
        public DateTime TGBatDau { get; set; }
        public DateTime TGKetThuc { get; set; }
        public string HinhAnh { get; set; }
        public string ThêLoaiQC { get; set; }
        public int ViTri { get; set; }
        public int ChieuDai { get; set; }
        public int ChieuRong { get; set; }
        [Required]
        public DateTime NgayTao { get; set; }
        public string NguoiTao { get; set; }
        public DateTime NgaySua { get; set; }
        public string NguoiSua { get; set; }
    }
}
