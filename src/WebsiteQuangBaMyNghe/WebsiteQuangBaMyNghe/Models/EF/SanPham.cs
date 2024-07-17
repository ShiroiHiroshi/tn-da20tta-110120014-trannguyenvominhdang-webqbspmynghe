using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebsiteQuangBaMyNghe.Models.EF
{
    [Table("SanPham")]
    public class SanPham
    {
        public SanPham() 
        { 
            this.AnhSanPhams= new HashSet<AnhSanPham>();
            this.ChiTietDonHangs= new HashSet<ChiTietDonHang>();
            this.BinhLuans = new HashSet<BinhLuan>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int MaSanPham { get; set; }
        [Required(ErrorMessage ="Ten san pham khong duoc de trong")]
        public string TenSanPham { get; set; }
        [Required(ErrorMessage = "Thong tin san pham khong duoc de trong")]
        public string MoTaSanPham { get; set; }
        [AllowHtml]
        public string ThongTinSanPham { get; set; }
        public string Image { get; set; }
        [Required(ErrorMessage = "Gia san pham khong duoc de trong")]
        public decimal Gia { get; set; }
        public decimal? GiaKhuyenMai { get; set; }
        public int SoLuong { get; set; }
        public string Alias { get; set; }
        public bool IsActive {  get; set; }
        public bool IsHot { get; set; }
        public bool IsSale { get; set; }
        public int MaDanhMuc { get; set; }
        public string MaDiaPhuong { get; set; }
        public virtual DanhMuc DanhMuc { get; set; }
        public virtual DiaPhuong DiaPhuong { get; set;}

        public virtual ICollection<AnhSanPham> AnhSanPhams { get; set; }
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual ICollection<BinhLuan> BinhLuans { get; set; }
    }
}