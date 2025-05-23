using Microsoft.AspNetCore.Mvc;
using CuaHangDienThoai.Data;
using CuaHangDienThoai.Models;

namespace CuaHangDienThoai.Controllers
{
    public class NguoiDungController : Controller
    {
        private readonly AppDbContext _context;

        public NguoiDungController(AppDbContext context)
        {
            _context = context;
        }

        // Hiển thị form đăng nhập
        [HttpGet]
        public IActionResult DangNhap()
        {
            return View();
        }

        // Xử lý đăng nhập
        [HttpPost]
        public IActionResult DangNhap(string ten_dang_nhap, string mat_khau)
        {
            var user = _context.NguoiDungs
                .FirstOrDefault(u => u.Ten_Dang_Nhap == ten_dang_nhap && u.Mat_Khau == mat_khau);

            if (user != null)
            {
                HttpContext.Session.SetInt32("IdNguoiDung", user.Id_NguoiDung);
                HttpContext.Session.SetString("TenNguoiDung", user.Ho_Ten);
                // Thêm dòng này để lưu tên đăng nhập
                HttpContext.Session.SetString("TenDangNhap", user.Ten_Dang_Nhap);
                return RedirectToAction("Index", "SanPham");
            }

            ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu sai.";
            return View();
        }

        
    }
}
