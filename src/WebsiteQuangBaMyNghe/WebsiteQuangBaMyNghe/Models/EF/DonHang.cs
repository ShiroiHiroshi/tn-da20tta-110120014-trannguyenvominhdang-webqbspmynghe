using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteQuangBaMyNghe.Models.EF
{
    [Table("DonHang")]
    public class DonHang
    {
        public DonHang() 
        {
            this.ChiTietDonHangs = new HashSet<ChiTietDonHang>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int MaDonHang { get; set; }
        public decimal ThanhTienDH { get; set; }
        public int Ma_KH {  get; set; }
        [Required(ErrorMessage = "Tên khách hàng không được để trống")]
        public string HoTen {  get; set; }
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        public string SoDienThoai {  get; set; }
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public DateTime NgayDatDH { get; set; }
        public int SoLuong {  get; set; }
        public int PhuongThucThanhToan { get; set; }
        public int TrangThaiDH { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        public virtual ICollection<ChiTietDonHang>  ChiTietDonHangs { get; set; }
    }
}