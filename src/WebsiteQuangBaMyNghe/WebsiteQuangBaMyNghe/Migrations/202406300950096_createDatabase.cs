namespace WebsiteQuangBaMyNghe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.SanPham", "MaDiaPhuong", "dbo.DiaPhuong");
            DropForeignKey("dbo.SanPham", "MaDanhMuc", "dbo.DanhMuc");
            DropForeignKey("dbo.BinhLuan", "MaSanPham", "dbo.SanPham");
            DropForeignKey("dbo.DonHang", "Ma_KH", "dbo.KhachHang");
            DropForeignKey("dbo.ChiTietDonHang", "MaSanPham", "dbo.SanPham");
            DropForeignKey("dbo.ChiTietDonHang", "MaDonHang", "dbo.DonHang");
            DropForeignKey("dbo.BinhLuan", "Ma_KH", "dbo.KhachHang");
            DropForeignKey("dbo.AnhSanPham", "MaSanPham", "dbo.SanPham");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ChiTietDonHang", new[] { "MaSanPham" });
            DropIndex("dbo.ChiTietDonHang", new[] { "MaDonHang" });
            DropIndex("dbo.DonHang", new[] { "Ma_KH" });
            DropIndex("dbo.BinhLuan", new[] { "Ma_KH" });
            DropIndex("dbo.BinhLuan", new[] { "MaSanPham" });
            DropIndex("dbo.SanPham", new[] { "MaDiaPhuong" });
            DropIndex("dbo.SanPham", new[] { "MaDanhMuc" });
            DropIndex("dbo.AnhSanPham", new[] { "MaSanPham" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.DiaPhuong");
            DropTable("dbo.DanhMuc");
            DropTable("dbo.ChiTietDonHang");
            DropTable("dbo.DonHang");
            DropTable("dbo.KhachHang");
            DropTable("dbo.BinhLuan");
            DropTable("dbo.SanPham");
            DropTable("dbo.AnhSanPham");
            DropTable("dbo.Admin");
        }
    }
}
