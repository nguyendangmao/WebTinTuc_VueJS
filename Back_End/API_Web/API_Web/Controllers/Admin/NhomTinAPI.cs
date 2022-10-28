using API_Web.Data;
using API_Web.Data.Table;
using API_Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;


namespace API_Web.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhomTinAPI : ControllerBase
    {
        private readonly MyDbContext _context;
        public NhomTinAPI(MyDbContext context)
        {
            _context = context;
        }

        //Lấy tất cả
        [HttpGet]
        public IActionResult GetAll()
        {
            var dsNhomTin = _context.NhomTinDb.ToList();
            return Ok(new
            {
                Success = true,
                Data = dsNhomTin

            });
        }
        //Lấy theo id
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var nhomtin = _context.NhomTinDb.SingleOrDefault(nt => nt.IDNhomTin == int.Parse(id));
                if (nhomtin == null)
                {
                    return NotFound();
                }
                return Ok(new
                {
                    Success = true,
                    Data = nhomtin

                });
            }
            catch
            {
                return BadRequest();
            }
        }
        //Thêm
        [HttpPost]
        public IActionResult Create(NhomTinn NhomtinAdd)
        {
            var nhomtin = new NhomTinDb
            {
                TenNhomTin = NhomtinAdd.TenNhomTin,
                ThuTuHienThi = NhomtinAdd.ThuTuHienThi,
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
        public IActionResult Edit(string id, NhomTinn NhomtinEdit)
        {
            try
            {
                var nhomtin = _context.NhomTinDb.SingleOrDefault(nt => nt.IDNhomTin == int.Parse(id));
                if (nhomtin == null)
                {
                    return NotFound();
                }
                if (id != nhomtin.IDNhomTin.ToString())
                {
                    return BadRequest();
                }
                nhomtin.TenNhomTin = NhomtinEdit.TenNhomTin;
                nhomtin.ThuTuHienThi = NhomtinEdit.ThuTuHienThi;
                nhomtin.NgaySua = DateTime.Now;
                nhomtin.NguoiSua = "ADMIN";
                _context.SaveChanges();
                return Ok(new
                {
                    Success = true,
                    Data = nhomtin

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
                var nhomtin = _context.NhomTinDb.SingleOrDefault(nt => nt.IDNhomTin == int.Parse(id));
                if (nhomtin == null)
                {
                    return NotFound();
                }
                _context.Remove(nhomtin);
                _context.SaveChanges();
                return Ok(new
                {
                    Success = true,
                    Data = nhomtin

                });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
