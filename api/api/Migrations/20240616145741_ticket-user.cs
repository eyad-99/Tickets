using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class ticketuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "edc267ec-d43c-4e3b-8108-a1a1f819906d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed040b70-b619-40e7-9d0a-79cec59e9300", "AQAAAAEAACcQAAAAEBf5nrFKv49kJgFNNw+Qdb8KRzwSjKPFtzqrO4szJMriNEtPVyF5vY3X8WjX7VmzKw==", "4984d186-115d-4b48-929f-e7dc233443a6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "edc267ec-d43c-4e3b-8108-a1a1f819906d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dbbd4944-09e1-4c10-ac89-52f8a42bbf40", "AQAAAAEAACcQAAAAEFnEeSRn6nyMShFfbzltmMzL9UTXHy2e5JUWjkIggWruY6pW0ZwyTZxpEePlFjcoTQ==", "4e0889f6-4299-4f02-af82-8398314543d8" });
        }
    }
}
