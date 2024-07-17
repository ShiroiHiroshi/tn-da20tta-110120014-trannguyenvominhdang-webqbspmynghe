using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteQuangBaMyNghe.Models.EF
{
    [Table("KhachHang")]
    public class KhachHang
    {
        public KhachHang()
        {
            this.DonHangs = new HashSet<DonHang>();
            this.BinhLuans = new HashSet<BinhLuan>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Ma_KH { get; set; }
        [Required(ErrorMessage = "Vui long nhap ten tai khoan")]
        public string TaiKhoan_KH { get; set; }
        [Required(ErrorMessage = "Vui long nhap mat khau tai khoan")]
        public string MatKhau_KH { get; set; }
        [Required(ErrorMessage = "Vui long nhap ho ten tai khoan")]
        public string Hoten { get; set; }
        [Required(ErrorMessage = "Vui long nhap Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Vui long nhap dia chi")]
        public string DiaChi { get; set; }
        [Required(ErrorMessage = "Vui long nhap so dien thoai")]
        public string SoDienThoai { get; set; }
        public ICollection<DonHang> DonHangs { get; set; }
        public virtual ICollection<BinhLuan> BinhLuans { get; set; }
    }
}