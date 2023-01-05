using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace joaodiasgeneric.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedIdendity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f8550a5c-4bd0-488d-bb46-929f414ccc25", null, "User", "USER" },
                    { "ff81c59d-a1fd-4b25-9c0d-17630ffcd011", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3840fe3c-5078-4dbc-b932-91c33a52b203", 0, "db7376af-3226-456e-8ce6-cd3209de26cd", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEPpKowCAEO3xK+aCqDoOw8VMNPvBfqL0xwsCZiiWZNtDIbDZF5sxi8juX6AvxtI8Hw==", null, false, "c541cff6-6dc1-42cf-a703-02f4e63f2dac", false, "admin@gmail.com" },
                    { "aa61ff61-f272-47b6-9f7a-0752abca1b40", 0, "ec4cbc79-cb74-4330-b8ca-a2668fc859a0", "usuario@gmail.com", true, false, null, "USUARIO@GMAIL.COM", "USUARIO@GMAIL.COM", "AQAAAAIAAYagAAAAEJWc91T88DFcRn0LSuXoCHwEZzH6mDpePKu+duViUpii4ygYh6JqTrzoqb2ICtOmeQ==", null, false, "ee522306-f461-4938-bc7c-09b39b276646", false, "usuario@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "f8550a5c-4bd0-488d-bb46-929f414ccc25", "3840fe3c-5078-4dbc-b932-91c33a52b203" },
                    { "ff81c59d-a1fd-4b25-9c0d-17630ffcd011", "aa61ff61-f272-47b6-9f7a-0752abca1b40" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
              table: "AspNetUserRoles",
              keyColumns: new[] { "RoleId", "UserId" },
              keyValues: new object[] { "f8550a5c-4bd0-488d-bb46-929f414ccc25", "3840fe3c-5078-4dbc-b932-91c33a52b203" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ff81c59d-a1fd-4b25-9c0d-17630ffcd011", "aa61ff61-f272-47b6-9f7a-0752abca1b40" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8550a5c-4bd0-488d-bb46-929f414ccc25");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff81c59d-a1fd-4b25-9c0d-17630ffcd011");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3840fe3c-5078-4dbc-b932-91c33a52b203");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aa61ff61-f272-47b6-9f7a-0752abca1b40");
        }
    }
}
