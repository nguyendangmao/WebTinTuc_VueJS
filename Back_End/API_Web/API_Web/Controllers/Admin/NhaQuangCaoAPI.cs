using API_Web.Data.Table;
using API_Web.Data;
using API_Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace API_Web.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhaQuangCaoAPI : ControllerBase
    {
        private readonly MyDbContext _context;
        public NhaQuangCaoAPI(MyDbContext context)
        {
            _context = context;
        }

        //Lấy tất cả
        [HttpGet]
        public IActionResult GetAll()
        {
            var dsNhaQuangCao = _context.NhaQuangCaoDb.ToList();
            return Ok(new
            {
                Success = true,
                Data = dsNhaQuangCao

            });
        }
        //Lấy theo id
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var quangcao = _context.NhaQuangCaoDb.SingleOrDefault(nt => nt.IDNQC == int.Parse(id));
                if (quangcao == null)
                {
                    return NotFound();
                }
                return Ok(new
                {
                    Success = true,
                    Data = quangcao

                });
            }
            catch
            {
                return BadRequest();
            }
        }
        //Thêm
        [HttpPost]
        public IActionResult Create(NhaQuangCaoo NhaQuangCaoAdd)
        {
            var quangcao = new NhaQuangCaoDb
            {
                TenNQC = NhaQuangCaoAdd.TenNQC,
                NgayTao = DateTime.Now,
                NguoiTao = "ADMIN"

            };
            _context.Add(quangcao);
            _context.SaveChanges();
            return Ok(new
            {
                Success = true,
                Data = quangcao

            });
        }
        //Sửa
        [HttpPut("{id}")]
        public IActionResult Edit(string id, NhaQuangCaoo NhaQuangCaoEdit)
        {
            try
            {
                var quangcao = _context.NhaQuangCaoDb.SingleOrDefault(nt => nt.IDNQC == int.Parse(id));
                if (quangcao == null)
                {
                    return NotFound();
                }
                if (id != quangcao.IDNQC.ToString())
                {
                    return BadRequest();
                }
                quangcao.TenNQC = NhaQuangCaoEdit.TenNQC;
                quangcao.NgaySua = DateTime.Now;
                quangcao.NguoiSua = "ADMIN";
                _context.SaveChanges();
                return Ok(new
                {
                    Success = true,
                    Data = quangcao

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
                var quangcao = _context.NhaQuangCaoDb.SingleOrDefault(nt => nt.IDNQC == int.Parse(id));
                if (quangcao == null)
                {
                    return NotFound();
                }
                _context.Remove(quangcao);
                _context.SaveChanges();
                return Ok(new
                {
                    Success = true,
                    Data = quangcao

                });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
