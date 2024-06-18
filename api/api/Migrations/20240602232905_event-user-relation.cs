using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class eventuserrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "edc267ec-d43c-4e3b-8108-a1a1f819906d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10c54473-503f-4cd0-8f2d-e34537bf17d3", "AQAAAAEAACcQAAAAEIu7wnLCiX00mu4ltQOqnRQm3b5vtDWE3bip5pRJW9JALpM5bQwAEQo5PLx9GQZqqg==", "70094f7e-1ed1-4866-8df1-fedc512eaee9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "edc267ec-d43c-4e3b-8108-a1a1f819906d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd066c22-e5f7-48cf-95ae-ba4e7163c839", "AQAAAAEAACcQAAAAEHX7LWv5kZwSX7Nv7AyNjYaQ+IOYIe4S+uRBNFoYDqUHd39Hc8rlt7m63TtZQt2ItQ==", "eb682a6e-60e1-48c6-a2f8-a3250a20dc6c" });
        }
    }
}
