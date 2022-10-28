using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Web.Data.Table
{
    [Table("TheLoai")]
    public class TheLoaiDb
    {
        [Key]
        public int IDTheLoai { get; set; }
        [Required]
        public string TenTheLoai { get; set; }
        [Required]
        public DateTime NgayTao { get; set; }
        [Required]
        public string NguoiTao { get; set; }
        public DateTime NgaySua { get; set; }
        public string NguoiSua { get; set; }
    }
}
