using Microsoft.AspNetCore.Mvc;
using CuaHangDienThoai.Data;
using CuaHangDienThoai.Models;

namespace CuaHangDienThoai.Controllers
{
    public class DonHangController : Controller
    {
        private readonly AppDbContext _context;

        public DonHangController(AppDbContext context)
        {
            _context = context;
        }

        // GET: DonHang/Mua/5
        public IActionResult Mua(int id)
        {
            var sanPham = _context.SanPhams.FirstOrDefault(sp => sp.Id_SanPham == id);
            if (sanPham == null) return NotFound();

            ViewBag.SanPham = sanPham;
            return View();
        }

        // POST: DonHang/Mua
        [HttpPost]
        public IActionResult Mua(int id_san_pham, int so_luong, string dia_chi)
        {
            int? idNguoiDung = HttpContext.Session.GetInt32("IdNguoiDung");
            if (idNguoiDung == null)
                return RedirectToAction("DangNhap", "NguoiDung");

            var sanPham = _context.SanPhams.FirstOrDefault(sp => sp.Id_SanPham == id_san_pham);
            if (sanPham == null || so_luong <= 0 || so_luong > sanPham.So_Luong)
            {
                ViewBag.ThongBao = "Số lượng không hợp lệ hoặc sản phẩm không còn đủ.";
                ViewBag.SanPham = sanPham;
                return View();
            }

            var donHang = new DonHang
            {
                Id_NguoiDung = idNguoiDung.Value,
                Dia_Chi = dia_chi,
                Ngay_Tao = DateTime.Now,
                Tong_Tien = sanPham.Gia * so_luong
            };

            try
            {

                _context.DonHangs.Add(donHang);
                _context.SaveChanges();

                var chiTiet = new ChiTietDonHang
                {
                    Id_DonHang = donHang.Id_DonHang,
                    Id_SanPham = id_san_pham,
                    So_Luong = so_luong,
                    Gia = sanPham.Gia
                };
                _context.ChiTietDonHangs.Add(chiTiet);

                // Cập nhật tồn kho
                sanPham.So_Luong -= so_luong;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                ViewBag.ThongBao = "Có lỗi khi lưu đơn hàng: " + ex.Message;
                ViewBag.SanPham = sanPham;
                return View();
            }
            return RedirectToAction("Index", "SanPham");
        }
    }
}
