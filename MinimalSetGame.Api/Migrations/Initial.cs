#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MinimalSetGame.Api.Migrations;

/// <inheritdoc />
public partial class Initial : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
        "AspNetRoles",
        columns: table => new
        {
            Id = table.Column<Guid>("uuid", nullable: false),
            Name = table.Column<string>(
            "character varying(256)",
            maxLength: 256,
            nullable: true),
            NormalizedName = table.Column<string>(
            "character varying(256)",
            maxLength: 256,
            nullable: true),
            ConcurrencyStamp = table.Column<string>("text", nullable: true)
        },
        constraints: table =>
        {
            table.PrimaryKey("PK_AspNetRoles", columns: x => x.Id);
        });

        migrationBuilder.CreateTable(
        "AspNetUsers",
        columns: table => new
        {
            Id = table.Column<Guid>("uuid", nullable: false),
            UserName = table.Column<string>(
            "character varying(256)",
            maxLength: 256,
            nullable: true),
            NormalizedUserName = table.Column<string>(
            "character varying(256)",
            maxLength: 256,
            nullable: true),
            Email = table.Column<string>(
            "character varying(256)",
            maxLength: 256,
            nullable: true),
            NormalizedEmail = table.Column<string>(
            "character varying(256)",
            maxLength: 256,
            nullable: true),
            EmailConfirmed = table.Column<bool>("boolean", nullable: false),
            PasswordHash = table.Column<string>("text", nullable: true),
            SecurityStamp = table.Column<string>("text", nullable: true),
            ConcurrencyStamp = table.Column<string>("text", nullable: true),
            PhoneNumber = table.Column<string>("text", nullable: true),
            PhoneNumberConfirmed = table.Column<bool>("boolean", nullable: false),
            TwoFactorEnabled = table.Column<bool>("boolean", nullable: false),
            LockoutEnd = table.Column<DateTimeOffset>(
            "timestamp with time zone",
            nullable: true),
            LockoutEnabled = table.Column<bool>("boolean", nullable: false),
            AccessFailedCount = table.Column<int>("integer", nullable: false)
        },
        constraints: table =>
        {
            table.PrimaryKey("PK_AspNetUsers", columns: x => x.Id);
        });

        migrationBuilder.CreateTable(
        "AspNetRoleClaims",
        columns: table => new
        {
            Id = table.Column<int>("integer", nullable: false)
                .Annotation(
                "Npgsql:ValueGenerationStrategy",
                NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            RoleId = table.Column<Guid>("uuid", nullable: false),
            ClaimType = table.Column<string>("text", nullable: true),
            ClaimValue = table.Column<string>("text", nullable: true)
        },
        constraints: table =>
        {
            table.PrimaryKey("PK_AspNetRoleClaims", columns: x => x.Id);
            table.ForeignKey(
            "FK_AspNetRoleClaims_AspNetRoles_RoleId",
            column: x => x.RoleId,
            "AspNetRoles",
            "Id",
            onDelete: ReferentialAction.Cascade);
        });

        migrationBuilder.CreateTable(
        "AspNetUserClaims",
        columns: table => new
        {
            Id = table.Column<int>("integer", nullable: false)
                .Annotation(
                "Npgsql:ValueGenerationStrategy",
                NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            UserId = table.Column<Guid>("uuid", nullable: false),
            ClaimType = table.Column<string>("text", nullable: true),
            ClaimValue = table.Column<string>("text", nullable: true)
        },
        constraints: table =>
        {
            table.PrimaryKey("PK_AspNetUserClaims", columns: x => x.Id);
            table.ForeignKey(
            "FK_AspNetUserClaims_AspNetUsers_UserId",
            column: x => x.UserId,
            "AspNetUsers",
            "Id",
            onDelete: ReferentialAction.Cascade);
        });

        migrationBuilder.CreateTable(
        "AspNetUserLogins",
        columns: table => new
        {
            LoginProvider = table.Column<string>("text", nullable: false),
            ProviderKey = table.Column<string>("text", nullable: false),
            ProviderDisplayName = table.Column<string>("text", nullable: true),
            UserId = table.Column<Guid>("uuid", nullable: false)
        },
        constraints: table =>
        {
            table.PrimaryKey(
            "PK_AspNetUserLogins",
            columns: x => new { x.LoginProvider, x.ProviderKey });
            table.ForeignKey(
            "FK_AspNetUserLogins_AspNetUsers_UserId",
            column: x => x.UserId,
            "AspNetUsers",
            "Id",
            onDelete: ReferentialAction.Cascade);
        });

        migrationBuilder.CreateTable(
        "AspNetUserRoles",
        columns: table => new
        {
            UserId = table.Column<Guid>("uuid", nullable: false),
            RoleId = table.Column<Guid>("uuid", nullable: false)
        },
        constraints: table =>
        {
            table.PrimaryKey(
            "PK_AspNetUserRoles",
            columns: x => new { x.UserId, x.RoleId });
            table.ForeignKey(
            "FK_AspNetUserRoles_AspNetRoles_RoleId",
            column: x => x.RoleId,
            "AspNetRoles",
            "Id",
            onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
            "FK_AspNetUserRoles_AspNetUsers_UserId",
            column: x => x.UserId,
            "AspNetUsers",
            "Id",
            onDelete: ReferentialAction.Cascade);
        });

        migrationBuilder.CreateTable(
        "AspNetUserTokens",
        columns: table => new
        {
            UserId = table.Column<Guid>("uuid", nullable: false),
            LoginProvider = table.Column<string>("text", nullable: false),
            Name = table.Column<string>("text", nullable: false),
            Value = table.Column<string>("text", nullable: true)
        },
        constraints: table =>
        {
            table.PrimaryKey(
            "PK_AspNetUserTokens",
            columns: x => new { x.UserId, x.LoginProvider, x.Name });
            table.ForeignKey(
            "FK_AspNetUserTokens_AspNetUsers_UserId",
            column: x => x.UserId,
            "AspNetUsers",
            "Id",
            onDelete: ReferentialAction.Cascade);
        });

        migrationBuilder.CreateIndex(
        "IX_AspNetRoleClaims_RoleId",
        "AspNetRoleClaims",
        "RoleId");

        migrationBuilder.CreateIndex(
        "RoleNameIndex",
        "AspNetRoles",
        "NormalizedName",
        unique: true);

        migrationBuilder.CreateIndex(
        "IX_AspNetUserClaims_UserId",
        "AspNetUserClaims",
        "UserId");

        migrationBuilder.CreateIndex(
        "IX_AspNetUserLogins_UserId",
        "AspNetUserLogins",
        "UserId");

        migrationBuilder.CreateIndex(
        "IX_AspNetUserRoles_RoleId",
        "AspNetUserRoles",
        "RoleId");

        migrationBuilder.CreateIndex(
        "EmailIndex",
        "AspNetUsers",
        "NormalizedEmail");

        migrationBuilder.CreateIndex(
        "UserNameIndex",
        "AspNetUsers",
        "NormalizedUserName",
        unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
        name: "AspNetRoleClaims");

        migrationBuilder.DropTable(
        name: "AspNetUserClaims");

        migrationBuilder.DropTable(
        name: "AspNetUserLogins");

        migrationBuilder.DropTable(
        name: "AspNetUserRoles");

        migrationBuilder.DropTable(
        name: "AspNetUserTokens");

        migrationBuilder.DropTable(
        name: "AspNetRoles");

        migrationBuilder.DropTable(
        name: "AspNetUsers");
    }
}
