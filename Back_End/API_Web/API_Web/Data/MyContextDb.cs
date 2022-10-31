using API_Web.Data.Table;
using Microsoft.EntityFrameworkCore;

namespace API_Web.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        public DbSet<NhomTinDb> NhomTinDb { get; set; }
        public DbSet<NhaQuangCaoDb> NhaQuangCaoDb { get; set; }
        public DbSet<PhanQuyenDb> PhanQuyenDb { get; set; }
        public DbSet<TheLoaiDb> TheLoaiDb { get; set; }
        public DbSet<NguoiDungDb> NguoiDungDb { get; set; }
        public DbSet<QuangCaoDb> QuangCaoDb { get; set; }
        public DbSet<BaiVietDb> BaiVietDb { get; set; }

        }
    }
