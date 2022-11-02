using API_Web.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API_Web.Controllers.Validation
{
    [Route("api/[controller]")]
    [ApiController]
    public class Check_Delete : ControllerBase
    {
        private readonly MyDbContext _context;
        public Check_Delete(MyDbContext context)
        {
            _context = context;
        }
        //Check xem có bài viết nào tồn tại thể loại cần xóa  không
        [Route("Check_TheLoai/{IDTheLoai}")]
        [HttpGet]
        public IActionResult CheckbyId(string IDTheLoai)
        {
            try
            {
                var theloai = _context.BaiVietDb.Where(nt => nt.IDTheLoai == int.Parse(IDTheLoai));
                if (theloai == null)
                {
                    return NotFound();
                }
                return Ok(theloai);
            }
            catch
            {
                return BadRequest();
            }
        }
        //Check xem có bài viết nào tồn tại nhóm tin cần xóa  không
        [Route("Check_NhomTin/{IDNhomTin}")]
        [HttpGet]
        public IActionResult CheckbyId1(string IDNhomTin)
        {
            try
            {
                var nhomtin = _context.BaiVietDb.Where(nt => nt.IDNhomTin == int.Parse(IDNhomTin));
                if (nhomtin == null)
                {
                    return NotFound();
                }
                return Ok(nhomtin);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
