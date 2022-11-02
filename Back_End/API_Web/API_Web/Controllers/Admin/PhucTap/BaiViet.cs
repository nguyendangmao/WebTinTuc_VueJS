using API_Web.Data.Table;
using API_Web.Data;
using API_Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;

namespace API_Web.Controllers.Admin.PhucTap
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaiViet : ControllerBase
    {
        private readonly MyDbContext _context;
        public BaiViet(MyDbContext context)
        {
            _context = context;
        }
        
        //Lấy tất cả
        [HttpGet]
        public IActionResult GetAll()
        {
            var dsBaiViet = _context.BaiVietDb.ToList();
            var dsNhomTin = _context.NhomTinDb.ToList();
            var dsTheLoai = _context.TheLoaiDb.ToList();
            var dsQuangCao = _context.QuangCaoDb.ToList();

            var ds = (from bv in dsBaiViet
                        join nt in dsNhomTin on bv.IDNhomTin equals nt.IDNhomTin
                        join tl in dsTheLoai on bv.IDTheLoai equals tl.IDTheLoai
                        join qc in dsQuangCao on bv.IDQuangCao equals qc.IDQuangCao
                        select new
                        {
                            IDBaiViet = bv.IDBaiViêt,
                            TenBaiViet = bv.TenBaiViet,
                            TenNhomTin = nt.TenNhomTin,
                            TenTheLoai = tl.TenTheLoai,
                            QuangCao = qc.NoiDungQC,
                            NoiDungBaiViet = bv.NoiDungBaiViet,
                            HinhAnh = bv.HinhAnh,
                            SoSaoTB = bv.SoSaoTB,
                            LuotXem = bv.LuotXem,
                            NgaySua = bv.NgaySua,
                            NguoiSua = bv.NguoiSua,
                        });
            return Ok(ds);
        }
        //Lấy theo id
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var dsBaiViet = _context.BaiVietDb.ToList();
            var dsNhomTin = _context.NhomTinDb.ToList();
            var dsTheLoai = _context.TheLoaiDb.ToList();
            var dsQuangCao = _context.QuangCaoDb.ToList();

            var ds = (from bv in dsBaiViet
                      join nt in dsNhomTin on bv.IDNhomTin equals nt.IDNhomTin
                      join tl in dsTheLoai on bv.IDTheLoai equals tl.IDTheLoai
                      join qc in dsQuangCao on bv.IDQuangCao equals qc.IDQuangCao
                      select new
                      {
                          IDBaiViet = bv.IDBaiViêt,
                          TenBaiViet = bv.TenBaiViet,
                          TenNhomTin = nt.TenNhomTin,
                          TenTheLoai = tl.TenTheLoai,
                          QuangCao = qc.NoiDungQC,
                          NoiDungBaiViet = bv.NoiDungBaiViet,
                          HinhAnh = bv.HinhAnh,
                          SoSaoTB = bv.SoSaoTB,
                          LuotXem = bv.LuotXem,
                          NgaySua = bv.NgaySua,
                          NguoiSua = bv.NguoiSua,
                      });
            try
            {
                var baiviet = ds.SingleOrDefault(nt => nt.IDBaiViet == int.Parse(id));
                if (baiviet == null)
                {
                    return NotFound();
                }
                return Ok(baiviet);
            }
            catch
            {
                return BadRequest();
            }
        }
        //Thêm
        [HttpPost]
        public IActionResult Create(BaiViett BaiVietAdd)
        {
            try
            {
                var baiviet = new BaiVietDb
                {
                    IDNhomTin = BaiVietAdd.IDNhomTin,
                    IDTheLoai = BaiVietAdd.IDTheLoai,
                    IDQuangCao = BaiVietAdd.IDQuangCao,
                    TenBaiViet = BaiVietAdd.TenBaiViet,
                    NoiDungBaiViet = BaiVietAdd.NoiDungBaiViet,
                    HinhAnh = BaiVietAdd.HinhAnh,
                    SoSaoTB = BaiVietAdd.SoSaoTB,
                    LuotXem = BaiVietAdd.LuotXem,
                    NgayTao = DateTime.Now,
                    NguoiTao = "ADMIN"

                };
                _context.Add(baiviet);
                var IdNT = _context.NhomTinDb.SingleOrDefault(nt => nt.IDNhomTin == baiviet.IDNhomTin);
                var IdTL = _context.TheLoaiDb.SingleOrDefault(nt => nt.IDTheLoai == baiviet.IDTheLoai);
                var IdQC = _context.QuangCaoDb.SingleOrDefault(nt => nt.IDQuangCao == baiviet.IDQuangCao);
                if (IdNT != null && IdTL != null && IdQC != null)
                {
                    _context.SaveChanges();
                    return StatusCode(StatusCodes.Status201Created, baiviet);
                }
                return StatusCode(StatusCodes.Status412PreconditionFailed);
            }
            catch
            {
                return BadRequest();
            }
        }
        //Sửa
        [HttpPut("{id}")]
        public IActionResult Edit(string id, BaiViett BaiVietEdit)
        {
            try
            {
                var baiviet = _context.BaiVietDb.SingleOrDefault(nt => nt.IDBaiViêt == int.Parse(id));
                if (baiviet == null)
                {
                    return NotFound();
                }
                if (id != baiviet.IDBaiViêt.ToString())
                {
                    return BadRequest();
                }
                baiviet.IDNhomTin = BaiVietEdit.IDNhomTin;
                baiviet.IDTheLoai = BaiVietEdit.IDTheLoai;
                baiviet.IDQuangCao = BaiVietEdit.IDQuangCao;        
                baiviet.TenBaiViet = BaiVietEdit.TenBaiViet;
                baiviet.NoiDungBaiViet = BaiVietEdit.NoiDungBaiViet;
                baiviet.HinhAnh = BaiVietEdit.HinhAnh;
                baiviet.SoSaoTB = BaiVietEdit.SoSaoTB;
                baiviet.LuotXem = BaiVietEdit.LuotXem;    
                baiviet.NgaySua = DateTime.Now;
                baiviet.NguoiSua = "ADMIN";
                var IdNT = _context.NhomTinDb.SingleOrDefault(nt => nt.IDNhomTin == baiviet.IDNhomTin);
                var IdTL = _context.TheLoaiDb.SingleOrDefault(nt => nt.IDTheLoai == baiviet.IDTheLoai);
                var IdQC = _context.QuangCaoDb.SingleOrDefault(nt => nt.IDQuangCao == baiviet.IDQuangCao);
                if (IdNT != null && IdTL != null && IdQC != null)
                {
                    _context.SaveChanges();
                    return StatusCode(StatusCodes.Status201Created, baiviet);
                }
                return StatusCode(StatusCodes.Status412PreconditionFailed);

            }
            catch
            {
                return BadRequest();
            }
        }
        //Xóa
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var baiviet = _context.BaiVietDb.SingleOrDefault(nt => nt.IDBaiViêt == int.Parse(id));
                if (baiviet == null)
                {
                    return NotFound();
                }
                _context.Remove(baiviet);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
