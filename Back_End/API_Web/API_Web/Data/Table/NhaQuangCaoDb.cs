using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Web.Data.Table
{
    [Table("NhaQuangCao")]
    public class NhaQuangCaoDb
    {
        [Key]
        public int IDNQC { get; set; }
        [Required]
        public string TenNQC { get; set; }
        [Required]
        public DateTime NgayTao { get; set; }
        [Required]
        public string NguoiTao { get; set; }
        public DateTime NgaySua { get; set; }
        public string NguoiSua { get; set; }
    }
}
