using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class TicketsDB1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReserveDate",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "edc267ec-d43c-4e3b-8108-a1a1f819906d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dbbd4944-09e1-4c10-ac89-52f8a42bbf40", "AQAAAAEAACcQAAAAEFnEeSRn6nyMShFfbzltmMzL9UTXHy2e5JUWjkIggWruY6pW0ZwyTZxpEePlFjcoTQ==", "4e0889f6-4299-4f02-af82-8398314543d8" });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EventId",
                table: "Tickets",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Events_EventId",
                table: "Tickets",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Events_EventId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_EventId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ReserveDate",
                table: "Tickets");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "edc267ec-d43c-4e3b-8108-a1a1f819906d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "82c397ad-c005-48e6-88c7-711eb2bf4ede", "AQAAAAEAACcQAAAAEFw4eVrvJl1lZsCIxIJIGo4m3bN5jGv3nuoqTooBSKmSmPq9WWxkvQwi2T59XDqBUA==", "8f49b1dd-410f-4d12-bf16-b62a22ebb0b7" });
        }
    }
}
