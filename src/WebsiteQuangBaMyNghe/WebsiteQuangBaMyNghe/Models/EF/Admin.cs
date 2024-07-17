using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteQuangBaMyNghe.Models.EF
{
    [Table("Admin")]
    public class Admin
    {

        [Key]
        [Required(ErrorMessage = "Vui long nhap tai khoan")]
        public string TaiKhoan_AD { get; set; }
        [Required(ErrorMessage = "Vui long nhap mat khau")]
        public string MatKhau_AD { get; set; }

    }
}