using API_Web.Controllers.Admin.PhucTap;
using API_Web.Models;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MediaBrowser.Model.Attributes;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace API_Web.Data.Table
{
    [Table("QuangCao")]
    public partial class QuangCaoDb
    {
        [Key]
        public int IDQuangCao { get; set; }
        [Required]
        [ForeignKey("IDNQC")]
        public int IDNQC { get; set; }
        public string NoiDungQC { get; set; }
        public string TienQC { get; set; }
        public DateTime TGBatDau { get; set; }
        public DateTime TGKetThuc { get; set; }
        public string HinhAnh { get; set; }
        public string ThêLoaiQC { get; set; }
        public int ViTri { get; set; }
        [MaxValue(500)]
        public int ChieuDai { get; set; }
        [MaxValue(500)]
        public int ChieuRong { get; set; }
        [Required]
        public DateTime NgayTao { get; set; }
        public string NguoiTao { get; set; }
        public DateTime NgaySua { get; set; }
        public string NguoiSua { get; set; }

    }
}
