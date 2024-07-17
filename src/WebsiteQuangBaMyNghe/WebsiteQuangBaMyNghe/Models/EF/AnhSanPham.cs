using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteQuangBaMyNghe.Models.EF
{
    [Table("AnhSanPham")]
    public class AnhSanPham
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int MaSanPham { get; set; }
        public string Image { get; set; }
        public bool IsDefault { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}