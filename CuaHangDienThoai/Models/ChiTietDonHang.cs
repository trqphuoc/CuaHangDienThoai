using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuaHangDienThoai.Models
{
    public class ChiTietDonHang
    {
        [Key]
        public int Id_ChiTietDonHang { get; set; }

        [ForeignKey("DonHang")]
        public int Id_DonHang { get; set; }

        [ForeignKey("SanPham")]
        public int Id_SanPham { get; set; }

        public int So_Luong { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Gia { get; set; }

        public DonHang DonHang { get; set; }
        public SanPham SanPham { get; set; }
    }
}
