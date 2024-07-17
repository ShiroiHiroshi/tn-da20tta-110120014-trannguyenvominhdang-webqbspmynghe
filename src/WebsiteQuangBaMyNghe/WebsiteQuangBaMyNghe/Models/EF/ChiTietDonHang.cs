using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Net;

namespace WebsiteQuangBaMyNghe.Models.EF
{
    [Table("ChiTietDonHang")]
    public class ChiTietDonHang
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int MaDonHang { get; set; }
        public int MaSanPham { get; set; }
        public decimal Gia {  get; set; } 
        public int Soluong { get; set; }
        public virtual DonHang DonHang { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}