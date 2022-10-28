using API_Web.Data.Table;
using API_Web.Data;
using API_Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace API_Web.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhanQuyenAPI : ControllerBase
    {
        private readonly MyDbContext _context;
        public PhanQuyenAPI(MyDbContext context)
        {
            _context = context;
        }

        //Lấy tất cả
        [HttpGet]
        public IActionResult GetAll()
        {
            var dsPhanQuyen = _context.PhanQuyenDb.ToList();
            return Ok(new
            {
                Success = true,
                Data = dsPhanQuyen

            });
        }
        //Lấy theo id
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var phanquyen = _context.PhanQuyenDb.SingleOrDefault(nt => nt.IDPhanQuyen == int.Parse(id));
                if (phanquyen == null)
                {
                    return NotFound();
                }
                return Ok(new
                {
                    Success = true,
                    Data = phanquyen

                });
            }
            catch
            {
                return BadRequest();
            }
        }
        //Thêm
        [HttpPost]
        public IActionResult Create(PhanQuyenn PhanQuyenAdd)
        {
            var nhomtin = new NhomTinDb
            {
                TenNhomTin = PhanQuyenAdd.TenQuyen,
                NgayTao = DateTime.Now,
                NguoiTao = "ADMIN"

            };
            _context.Add(nhomtin);
            _context.SaveChanges();
            return Ok(new
            {
                Success = true,
                Data = nhomtin

            });
        }
        //Sửa
        [HttpPut("{id}")]
        public IActionResult Edit(string id, PhanQuyenn PhanQuyenEdit)
        {
            try
            {
                var phanquyen = _context.PhanQuyenDb.SingleOrDefault(nt => nt.IDPhanQuyen == int.Parse(id));
                if (phanquyen == null)
                {
                    return NotFound();
                }
                if (id != phanquyen.IDPhanQuyen.ToString())
                {
                    return BadRequest();
                }
                phanquyen.TenQuyen = PhanQuyenEdit.TenQuyen;
                phanquyen.NgaySua = DateTime.Now;
                phanquyen.NguoiSua = "ADMIN";
                _context.SaveChanges();
                return Ok(new
                {
                    Success = true,
                    Data = phanquyen

                });

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
                var phanquyen = _context.PhanQuyenDb.SingleOrDefault(nt => nt.IDPhanQuyen == int.Parse(id));
                if (phanquyen == null)
                {
                    return NotFound();
                }
                _context.Remove(phanquyen);
                _context.SaveChanges();
                return Ok(new
                {
                    Success = true,
                    Data = phanquyen

                });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
