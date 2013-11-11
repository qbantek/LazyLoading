using System.Data.Entity.Migrations;

namespace LazyLoading.Migrations
{
    public partial class Seed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clinics",
                c => new
                {
                    ClinicId = c.Int(nullable: false, identity: true),
                    Name = c.String(maxLength: 150),
                })
                .PrimaryKey(t => t.ClinicId);

            CreateTable(
                "dbo.ClinicTelephoneNumbers",
                c => new
                {
                    ClinicId = c.Int(nullable: false),
                    TelephoneNumberId = c.Int(nullable: false),
                })
                .PrimaryKey(t => new {t.ClinicId, t.TelephoneNumberId})
                .ForeignKey("dbo.Clinics", t => t.ClinicId, cascadeDelete: true)
                .ForeignKey("dbo.TelephoneNumbers", t => t.TelephoneNumberId, cascadeDelete: true)
                .Index(t => t.ClinicId)
                .Index(t => t.TelephoneNumberId);

            CreateTable(
                "dbo.TelephoneNumbers",
                c => new
                {
                    TelephoneNumberId = c.Int(nullable: false, identity: true),
                    PhoneType = c.Int(nullable: false),
                    PhoneNumber = c.String(nullable: false, maxLength: 50),
                    Deleted = c.Boolean(nullable: false),
                    DeletedOnUtc = c.DateTime(),
                    CreatedOnUtc = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.TelephoneNumberId);

            CreateTable(
                "dbo.AspNetRoles",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.AspNetUsers",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    UserName = c.String(),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    Discriminator = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    ClaimType = c.String(),
                    ClaimValue = c.String(),
                    User_Id = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);

            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128),
                    LoginProvider = c.String(nullable: false, maxLength: 128),
                    ProviderKey = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new {t.UserId, t.LoginProvider, t.ProviderKey})
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128),
                    RoleId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new {t.UserId, t.RoleId})
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ClinicTelephoneNumbers", "TelephoneNumberId", "dbo.TelephoneNumbers");
            DropForeignKey("dbo.ClinicTelephoneNumbers", "ClinicId", "dbo.Clinics");
            DropIndex("dbo.AspNetUserClaims", new[] {"User_Id"});
            DropIndex("dbo.AspNetUserRoles", new[] {"UserId"});
            DropIndex("dbo.AspNetUserRoles", new[] {"RoleId"});
            DropIndex("dbo.AspNetUserLogins", new[] {"UserId"});
            DropIndex("dbo.ClinicTelephoneNumbers", new[] {"TelephoneNumberId"});
            DropIndex("dbo.ClinicTelephoneNumbers", new[] {"ClinicId"});
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.TelephoneNumbers");
            DropTable("dbo.ClinicTelephoneNumbers");
            DropTable("dbo.Clinics");
        }
    }
}