using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuaHangDienThoai.Models
{
    public class DonHang
    {
        [Key]
        public int Id_DonHang { get; set; }

        [ForeignKey("NguoiDung")]
        public int Id_NguoiDung { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Tong_Tien { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Ngay_Tao { get; set; } = DateTime.Now;

        public string Dia_Chi { get; set; }

        public NguoiDung NguoiDung { get; set; }
        public ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public ICollection<DanhGia> DanhGias { get; set; }
    }
}
