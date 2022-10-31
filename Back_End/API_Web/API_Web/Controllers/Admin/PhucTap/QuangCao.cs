using API_Web.Controllers.Validation;
using API_Web.Data;
using API_Web.Data.Table;
using API_Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace API_Web.Controllers.Admin.PhucTap
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuangCao : ControllerBase
    {
        private readonly MyDbContext _context;
        public QuangCao(MyDbContext context)
        {
            _context = context;
        }
        //Lấy tất cả
        [HttpGet]
        public IActionResult GetAll()
        {
            var dsQuangCao = _context.QuangCaoDb.ToList();
            return Ok(dsQuangCao);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var quangcao = _context.QuangCaoDb.SingleOrDefault(nt => nt.IDQuangCao == int.Parse(id));
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
        public IActionResult Create(QuangCaoo QuangCaoAdd)
        {
            try
            {
                var quangcao = new QuangCaoDb
                {
                    IDNQC = QuangCaoAdd.IDNQC,
                    NoiDungQC = QuangCaoAdd.NoiDungQC,
                    TienQC = QuangCaoAdd.TienQC,
                    TGBatDau = QuangCaoAdd.TGBatDau,
                    TGKetThuc = QuangCaoAdd.TGKetThuc,
                    HinhAnh = QuangCaoAdd.HinhAnh,
                    ThêLoaiQC = QuangCaoAdd.ThêLoaiQC,
                    ViTri = QuangCaoAdd.ViTri,
                    ChieuDai = QuangCaoAdd.ChieuDai,
                    ChieuRong = QuangCaoAdd.ChieuRong,
                    NgayTao = DateTime.Now,
                    NguoiTao = "ADMIN"

                };
                _context.Add(quangcao);
                var IdNQC = _context.NhaQuangCaoDb.SingleOrDefault(nt => nt.IDNQC == quangcao.IDNQC);
                if (IdNQC != null)
                {
                    if (ValueNumBer.CheckSo(quangcao.ChieuDai, quangcao.ChieuRong))
                    {
                        _context.SaveChanges();
                        return StatusCode(StatusCodes.Status201Created, quangcao);
                    }
                    return StatusCode(StatusCodes.Status416RequestedRangeNotSatisfiable,"Chiều dài và chiều rộng phải lớn hơn 0 và nhỏ hơn 500");
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
        public IActionResult Edit(string id, QuangCaoo QuangCaoEdit)
        {
            try
            {
                var quangcao = _context.QuangCaoDb.SingleOrDefault(nt => nt.IDQuangCao == int.Parse(id));
                if (quangcao == null)
                {
                    return NotFound();
                }
                if (id != quangcao.IDQuangCao.ToString())
                {
                    return BadRequest();
                }
                quangcao.IDNQC = QuangCaoEdit.IDNQC;
                quangcao.NoiDungQC = QuangCaoEdit.NoiDungQC;
                quangcao.TienQC = QuangCaoEdit.TienQC;
                quangcao.TGBatDau = QuangCaoEdit.TGBatDau;
                quangcao.TGKetThuc = QuangCaoEdit.TGKetThuc;
                quangcao.HinhAnh = QuangCaoEdit.HinhAnh;
                quangcao.ThêLoaiQC = QuangCaoEdit.ThêLoaiQC;
                quangcao.ViTri = QuangCaoEdit.ViTri;
                quangcao.ChieuDai = QuangCaoEdit.ChieuDai;
                quangcao.ChieuRong = QuangCaoEdit.ChieuRong;
                quangcao.NgaySua = DateTime.Now;
                quangcao.NguoiSua = "ADMIN";
                var IdNQC = _context.NhaQuangCaoDb.SingleOrDefault(nt => nt.IDNQC == quangcao.IDNQC);
                if (IdNQC != null)
                {
                    if (ValueNumBer.CheckSo(quangcao.ChieuDai, quangcao.ChieuRong))
                    {
                        _context.SaveChanges();
                        return Ok();
                    }
                    return StatusCode(StatusCodes.Status416RequestedRangeNotSatisfiable, "Chiều dài và chiều rộng phải lớn hơn 0 và nhỏ hơn 500");
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
                var quangcao = _context.QuangCaoDb.SingleOrDefault(nt => nt.IDQuangCao == int.Parse(id));
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
