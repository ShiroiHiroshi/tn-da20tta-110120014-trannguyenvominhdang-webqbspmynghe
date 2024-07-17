using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteQuangBaMyNghe.Models.EF
{
    [Table("BinhLuan")]
    public class BinhLuan
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int MaBL { get; set; }
        public string NoiDungBL { get; set; }
        public DateTime NgayTao {  get; set; }
        public int DanhGia {  get; set; }
        [ForeignKey("SanPham")]
        public int MaSanPham { get; set; }
        public int Ma_KH { get; set; }
        public virtual SanPham SanPham { get; set; }
        public virtual KhachHang KhachHang { get; set; } 
    }
}