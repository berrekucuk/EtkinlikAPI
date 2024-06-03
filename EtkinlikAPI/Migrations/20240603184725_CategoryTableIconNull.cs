using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EtkinlikAPI.Migrations
{
    /// <inheritdoc />
    public partial class CategoryTableIconNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Icon",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "AddDate", "DeleteDate", "Icon", "IsDeleted", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("07850c19-3582-45fe-88c4-08c6fc427b25"), new DateTime(2024, 6, 3, 21, 47, 25, 520, DateTimeKind.Local).AddTicks(6344), null, null, false, "Sağlık", null },
                    { new Guid("35d3abe7-4fab-441f-87b4-b8933098f008"), new DateTime(2024, 6, 3, 21, 47, 25, 520, DateTimeKind.Local).AddTicks(6252), null, null, false, "Yazılım", null },
                    { new Guid("381fc20a-7935-4777-ba2e-ecbe26d70c62"), new DateTime(2024, 6, 3, 21, 47, 25, 520, DateTimeKind.Local).AddTicks(6402), null, null, false, "Müzik", null },
                    { new Guid("5423c642-8f66-46fa-bc50-56cc53617788"), new DateTime(2024, 6, 3, 21, 47, 25, 520, DateTimeKind.Local).AddTicks(6419), null, null, false, "Eğlence", null },
                    { new Guid("626e4518-d7bd-4968-8a31-817cd07708ee"), new DateTime(2024, 6, 3, 21, 47, 25, 520, DateTimeKind.Local).AddTicks(6384), null, null, false, "Sanat", null },
                    { new Guid("62ff6ba6-8dc3-489e-b36a-6efd9e6af739"), new DateTime(2024, 6, 3, 21, 47, 25, 520, DateTimeKind.Local).AddTicks(6362), null, null, false, "Spor", null },
                    { new Guid("6f8861e8-eb28-4d64-acb9-b0935f90bc23"), new DateTime(2024, 6, 3, 21, 47, 25, 520, DateTimeKind.Local).AddTicks(6296), null, null, false, "Teknoloji", null },
                    { new Guid("86b38118-cdb9-4fed-a2e1-470a14020a15"), new DateTime(2024, 6, 3, 21, 47, 25, 520, DateTimeKind.Local).AddTicks(6315), null, null, false, "Eğitim", null },
                    { new Guid("a8355910-f137-4e70-8766-042a22f3fa52"), new DateTime(2024, 6, 3, 21, 47, 25, 520, DateTimeKind.Local).AddTicks(6436), null, null, false, "Diğer", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("07850c19-3582-45fe-88c4-08c6fc427b25"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("35d3abe7-4fab-441f-87b4-b8933098f008"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("381fc20a-7935-4777-ba2e-ecbe26d70c62"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5423c642-8f66-46fa-bc50-56cc53617788"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("626e4518-d7bd-4968-8a31-817cd07708ee"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("62ff6ba6-8dc3-489e-b36a-6efd9e6af739"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6f8861e8-eb28-4d64-acb9-b0935f90bc23"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("86b38118-cdb9-4fed-a2e1-470a14020a15"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a8355910-f137-4e70-8766-042a22f3fa52"));

            migrationBuilder.AlterColumn<string>(
                name: "Icon",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
