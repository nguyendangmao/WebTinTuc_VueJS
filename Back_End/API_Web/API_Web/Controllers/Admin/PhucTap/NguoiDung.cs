using API_Web.Data;
using API_Web.Data.Table;
using API_Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace API_Web.Controllers.Admin.PhucTap
{
    [Route("api/[controller]")]
    [ApiController]
    public class NguoiDung : ControllerBase
    {
        private readonly MyDbContext _context;
        public NguoiDung(MyDbContext context)
        {
            _context = context;
        }

        //Lấy tất cả
        [HttpGet]
        public IActionResult GetAll()
        {
            var dsNguoiDung = _context.NguoiDungDb.ToList();
            return Ok(dsNguoiDung);
        }
        //Lấy theo id
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var nguoidung = _context.NguoiDungDb.SingleOrDefault(nt => nt.ID == int.Parse(id));
                if (nguoidung == null)
                {
                    return NotFound();
                }
                return Ok(nguoidung);
            }
            catch
            {
                return BadRequest();
            }
        }
        //Thêm
        [HttpPost]
        public IActionResult Create(NguoiDungg NguoiDungAdd)
        {
            try
            {
                var nguoidung = new NguoiDungDb
                {
                    IDPhanQuyen = NguoiDungAdd.IDPhanQuyen,
                    TenTk = NguoiDungAdd.TenTk,
                    MatKhau = NguoiDungAdd.MatKhau,
                    HoTen = NguoiDungAdd.HoTen,
                    GioiTinh = NguoiDungAdd.GioiTinh,
                    SDT = NguoiDungAdd.SDT,
                    TrangThai = NguoiDungAdd.TrangThai,
                    NgayTao = DateTime.Now,
                    NguoiTao = "ADMIN"

                };
                _context.Add(nguoidung);
                var IdPQ = _context.PhanQuyenDb.SingleOrDefault(nt => nt.IDPhanQuyen == nguoidung.IDPhanQuyen);
                if (IdPQ != null)
                {
                    _context.SaveChanges();
                    return StatusCode(StatusCodes.Status201Created, nguoidung);
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
        public IActionResult Edit(string id, NguoiDungg NguoiDungEdit)
        {
            try
            {
                var nguoidung = _context.NguoiDungDb.SingleOrDefault(nt => nt.ID == int.Parse(id));
                if (nguoidung == null)
                {
                    return NotFound();
                }
                if (id != nguoidung.ID.ToString())
                {
                    return BadRequest();
                }
                nguoidung.IDPhanQuyen = NguoiDungEdit.IDPhanQuyen;
                nguoidung.TenTk = NguoiDungEdit.TenTk;
                nguoidung.MatKhau = NguoiDungEdit.MatKhau;
                nguoidung.HoTen = NguoiDungEdit.HoTen;
                nguoidung.GioiTinh = NguoiDungEdit.GioiTinh;
                nguoidung.SDT = NguoiDungEdit.SDT;
                nguoidung.TrangThai = NguoiDungEdit.TrangThai;
                nguoidung.NgaySua = DateTime.Now;
                nguoidung.NguoiSua = "ADMIN";
                var IdPQ = _context.PhanQuyenDb.SingleOrDefault(nt => nt.IDPhanQuyen == nguoidung.IDPhanQuyen);
                if (IdPQ == null)
                {
                    return StatusCode(StatusCodes.Status412PreconditionFailed);
                }
                _context.SaveChanges();
                return Ok();

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
                var nguoidung = _context.NguoiDungDb.SingleOrDefault(nt => nt.ID == int.Parse(id));
                if (nguoidung == null)
                {
                    return NotFound();
                }
                _context.Remove(nguoidung);
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
