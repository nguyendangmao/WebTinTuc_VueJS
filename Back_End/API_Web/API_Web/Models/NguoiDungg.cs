using API_Web.Data.Table;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace API_Web.Models
{
    public class NguoiDungg
    {
        [Required]
        public int IDPhanQuyen { get; set; }
        [Required]
        public string TenTk { get; set; }
        public string MatKhau { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        [MaxLength(10)]
        public string SDT { get; set; }
        public TrangThai TrangThai { get; set; }
        [Required]
        public DateTime NgayTao { get; set; }
        public string NguoiTao { get; set; }
        public DateTime NgaySua { get; set; }
        public string NguoiSua { get; set; }

        //Khóa ngoại
        

    }
}
