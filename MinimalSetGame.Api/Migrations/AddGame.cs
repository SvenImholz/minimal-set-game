#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace MinimalSetGame.Api.Migrations;

/// <inheritdoc />
public partial class AddGame : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
        "FirstName",
        "AspNetUsers",
        "text",
        nullable: false,
        defaultValue: "");

        migrationBuilder.AddColumn<string>(
        "LastName",
        "AspNetUsers",
        "text",
        nullable: false,
        defaultValue: "");

        migrationBuilder.CreateTable(
        "Games",
        columns: table => new
        {
            Id = table.Column<Guid>("uuid", nullable: false),
            PlayerId = table.Column<Guid>("uuid", nullable: false),
            State = table.Column<int>("integer", nullable: false),
            CreatedAt = table.Column<DateTime>(
            "timestamp with time zone",
            nullable: false),
            FinishedAt = table.Column<DateTime>(
            "timestamp with time zone",
            nullable: true)
        },
        constraints: table =>
        {
            table.PrimaryKey("PK_Games", columns: x => x.Id);
            table.ForeignKey(
            "FK_Games_AspNetUsers_PlayerId",
            column: x => x.PlayerId,
            "AspNetUsers",
            "Id",
            onDelete: ReferentialAction.Cascade);
        });

        migrationBuilder.CreateTable(
        "Set",
        columns: table => new
        {
            Id = table.Column<Guid>("uuid", nullable: false),
            GameId = table.Column<Guid>("uuid", nullable: false)
        },
        constraints: table =>
        {
            table.PrimaryKey("PK_Set", columns: x => x.Id);
            table.ForeignKey(
            "FK_Set_Games_GameId",
            column: x => x.GameId,
            "Games",
            "Id",
            onDelete: ReferentialAction.Cascade);
        });

        migrationBuilder.CreateTable(
        "Card",
        columns: table => new
        {
            Id = table.Column<Guid>("uuid", nullable: false),
            GameId = table.Column<Guid>("uuid", nullable: false),
            Color = table.Column<int>("integer", nullable: false),
            Shape = table.Column<int>("integer", nullable: false),
            Fill = table.Column<int>("integer", nullable: false),
            Number = table.Column<int>("integer", nullable: false),
            IsDrawn = table.Column<bool>("boolean", nullable: false),
            SetId = table.Column<Guid>("uuid", nullable: true)
        },
        constraints: table =>
        {
            table.PrimaryKey("PK_Card", columns: x => x.Id);
            table.ForeignKey(
            "FK_Card_Games_GameId",
            column: x => x.GameId,
            "Games",
            "Id",
            onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
            "FK_Card_Set_SetId",
            column: x => x.SetId,
            "Set",
            "Id");
        });

        migrationBuilder.CreateIndex(
        "IX_Card_GameId",
        "Card",
        "GameId");

        migrationBuilder.CreateIndex(
        "IX_Card_SetId",
        "Card",
        "SetId");

        migrationBuilder.CreateIndex(
        "IX_Games_PlayerId",
        "Games",
        "PlayerId");

        migrationBuilder.CreateIndex(
        "IX_Set_GameId",
        "Set",
        "GameId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
        name: "Card");

        migrationBuilder.DropTable(
        name: "Set");

        migrationBuilder.DropTable(
        name: "Games");

        migrationBuilder.DropColumn(
        "FirstName",
        "AspNetUsers");

        migrationBuilder.DropColumn(
        "LastName",
        "AspNetUsers");
    }
}
