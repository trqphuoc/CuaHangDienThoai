using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuaHangDienThoai.Models
{
    public class DanhGia
    {
        [Key]
        public int Id_DanhGia { get; set; }

        [ForeignKey("NguoiDung")]
        public int Id_NguoiDung { get; set; }

        [ForeignKey("SanPham")]
        public int Id_SanPham { get; set; }

        [ForeignKey("DonHang")]
        public int Id_DonHang { get; set; }

        [Range(1, 5)]
        public int So_Sao { get; set; }

        [StringLength(500)]
        public string Nhan_Xet { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Ngay_DanhGia { get; set; } = DateTime.Now;

        public NguoiDung NguoiDung { get; set; }
        public SanPham SanPham { get; set; }
        public DonHang DonHang { get; set; }
    }
}
