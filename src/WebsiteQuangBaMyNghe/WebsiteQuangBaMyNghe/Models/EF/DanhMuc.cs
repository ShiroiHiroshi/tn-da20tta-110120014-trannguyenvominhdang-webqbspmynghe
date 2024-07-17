using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteQuangBaMyNghe.Models.EF
{
    [Table("DanhMuc")]
    public class DanhMuc
    {
        public DanhMuc() 
        {
            this.SanPhams = new HashSet<SanPham>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int MaDanhMuc { get; set; }
        [Required(ErrorMessage = "Ten danh muc khong duoc de trong")]
        public string TenDanhMuc { get; set; }
        public string MoTaDanhMuc { get; set; }
        public string Alias { get; set; }
        public string Icon { get; set; }
        public ICollection<SanPham> SanPhams { get; set; }
    }
}