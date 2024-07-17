using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteQuangBaMyNghe.Models.EF
{
        [Table("DiaPhuong")]
        public class DiaPhuong
        {
            public DiaPhuong()
            {
                this.SanPhams = new HashSet<SanPham>();
            }
            [Key]
            public string MaDiaPhuong { get; set; }
            public string TenDiaPhuong { get; set; }
            public ICollection<SanPham> SanPhams { get; set; }
        }
}