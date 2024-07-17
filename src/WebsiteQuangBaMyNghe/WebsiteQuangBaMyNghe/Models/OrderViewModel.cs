using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteQuangBaMyNghe.Models
{
    public class OrderViewModel
    {
        [Required(ErrorMessage ="Tên khách hàng không được để trống")]
        public string TenKhachHang { get; set; }
        [Required(ErrorMessage ="Số điện thoại không được để trống")]
        public string DienThoai { get; set; }
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string Ma_KH { get; set; }
        public int PhuongThucThanhToan {  get; set; }
        public int TrangThaiDH { get; set; }
    }
}