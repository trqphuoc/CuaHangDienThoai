using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuaHangDienThoai.Models
{
    public class SanPham
    {
        [Key]
        public int Id_SanPham { get; set; }

        [Required]
        [StringLength(100)]
        public string Ten_SanPham { get; set; }

        [Required]
        public string Mo_Ta { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Gia { get; set; }

        [Required]
        [StringLength(10)]
        public string DungLuongLuuTru { get; set; }

        [Required]
        [StringLength(10)]
        public string Ram { get; set; }

        [Required]
        [StringLength(10)]
        public string KichThuocManHinh { get; set; }

        [Required]
        [StringLength(10)]
        public string BaoHanh { get; set; }

        public int SoKheCamSim { get; set; }
        public int So_Luong { get; set; }

        public int? Id_DanhMuc { get; set; }
        public string Anh_Url { get; set; }

        [ForeignKey("Id_DanhMuc")]
        public DanhMuc DanhMuc { get; set; }

        public ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public ICollection<DanhGia> DanhGias { get; set; }
    }
}
