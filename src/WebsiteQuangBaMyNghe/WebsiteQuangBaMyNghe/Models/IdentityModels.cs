﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebsiteQuangBaMyNghe.Models.EF;

namespace WebsiteQuangBaMyNghe.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<BinhLuan> BinhLuans { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<DanhMuc> DanhMucs { get; set; }
        public DbSet<DiaPhuong> DiaPhuongs { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; } 
        public DbSet<AnhSanPham> AnhSanPhams { get; set; }
    public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}