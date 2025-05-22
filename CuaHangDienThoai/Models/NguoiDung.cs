using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuaHangDienThoai.Models
{
    public class NguoiDung
    {
        [Key]
        public int Id_NguoiDung { get; set; }

        [Required]
        [StringLength(50)]
        public string Ten_Dang_Nhap { get; set; }

        [Required]
        [StringLength(255)]
        public string Mat_Khau { get; set; }

        [Required]
        [StringLength(100)]
        public string Ho_Ten { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(15)]
        public string So_Dien_Thoai { get; set; }

        public string Dia_Chi { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Ngay_Tao { get; set; } = DateTime.Now;

        public ICollection<DonHang> DonHangs { get; set; }
        public ICollection<DanhGia> DanhGias { get; set; }
    }
}
