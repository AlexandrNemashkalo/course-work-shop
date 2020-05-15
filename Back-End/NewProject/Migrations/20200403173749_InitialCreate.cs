using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0effea99-79db-4434-8ad8-319f6cf08f44"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("29389daf-52ff-41ba-970d-65e990594313"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("3cfecb8c-817b-4cc5-99d0-29a7a373c174"), "9f0acd9c-8bd8-4295-9ec6-69cf8500d822", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("87413867-baf4-4701-997d-7b31e03c7c18"), "155e701a-466b-4cd9-92a9-de5784e400d0", "admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3cfecb8c-817b-4cc5-99d0-29a7a373c174"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("87413867-baf4-4701-997d-7b31e03c7c18"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("29389daf-52ff-41ba-970d-65e990594313"), "075bf9d6-5817-444a-9b1a-e64c3188bc7e", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("0effea99-79db-4434-8ad8-319f6cf08f44"), "b268dad8-3177-483a-b8f3-debfeab46599", "admin", "ADMIN" });
        }
    }
}
