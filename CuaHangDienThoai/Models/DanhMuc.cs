using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CuaHangDienThoai.Models
{
    public class DanhMuc
    {
        [Key]
        public int Id_DanhMuc { get; set; }

        [Required]
        [StringLength(50)]
        public string Ten_DanhMuc { get; set; }

        public ICollection<SanPham> SanPhams { get; set; }
    }
}
