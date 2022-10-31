using API_Web.Data.Table;
using API_Web.Data;
using API_Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace API_Web.Controllers.Admin.DonGian
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
            return Ok(dsNhaQuangCao);
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
                return Ok(quangcao);
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
            try
            {
                var nhaquangcao = new NhaQuangCaoDb
                {
                    TenNQC = NhaQuangCaoAdd.TenNQC,
                    NgayTao = DateTime.Now,
                    NguoiTao = "ADMIN"

                };
                _context.Add(nhaquangcao);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, nhaquangcao);
            }
            catch
            {
                return BadRequest();
            }
        }
        //Sửa
        [HttpPut("{id}")]
        public IActionResult Edit(string id, NhaQuangCaoo NhaQuangCaoEdit)
        {
            try
            {
                var nhaquangcao = _context.NhaQuangCaoDb.SingleOrDefault(nt => nt.IDNQC == int.Parse(id));
                if (nhaquangcao == null)
                {
                    return NotFound();
                }
                if (id != nhaquangcao.IDNQC.ToString())
                {
                    return BadRequest();
                }
                nhaquangcao.TenNQC = NhaQuangCaoEdit.TenNQC;
                nhaquangcao.NgaySua = DateTime.Now;
                nhaquangcao.NguoiSua = "ADMIN";
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
                var quangcao = _context.NhaQuangCaoDb.SingleOrDefault(nt => nt.IDNQC == int.Parse(id));
                if (quangcao == null)
                {
                    return NotFound();
                }
                _context.Remove(quangcao);
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
