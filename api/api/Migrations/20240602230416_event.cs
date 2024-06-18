using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class @event : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfTickets = table.Column<int>(type: "int", nullable: false),
                    RemainTickets = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "edc267ec-d43c-4e3b-8108-a1a1f819906d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd066c22-e5f7-48cf-95ae-ba4e7163c839", "AQAAAAEAACcQAAAAEHX7LWv5kZwSX7Nv7AyNjYaQ+IOYIe4S+uRBNFoYDqUHd39Hc8rlt7m63TtZQt2ItQ==", "eb682a6e-60e1-48c6-a2f8-a3250a20dc6c" });

            migrationBuilder.CreateIndex(
                name: "IX_Events_UserId",
                table: "Events",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "edc267ec-d43c-4e3b-8108-a1a1f819906d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1bdd8213-c1f3-4e5d-ba9a-fb28a8b2ddc3", "AQAAAAEAACcQAAAAEHkzzqQz7rHYFrAFnkI9AtO03lXy5/jlW9Q743IfEpFhdZQH2akyCcUDBI8eRaAYwQ==", "3f07bab0-7a71-4409-91d4-3d769ac38e3b" });
        }
    }
}
