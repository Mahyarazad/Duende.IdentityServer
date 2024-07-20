using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IdentityServer.Migrations
{
    /// <inheritdoc />
    public partial class UserLogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("06269e8c-6c23-4406-b87b-42269c6545d3"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("22244a3e-6c60-4b14-9778-03b6ed13f717"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("272a478c-0630-47e0-ac65-609c5efd6fb1"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("32e7e057-f081-4a47-8c86-eda16fec5cc9"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("68966e98-1c93-4b2b-a844-09b650d408e0"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("6b2ca7fe-adbf-42af-9d67-d379b4791baa"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("b5366b41-5efc-41bd-8617-eec1eda5582c"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("b8c8ec03-6a27-44da-a34f-c2d470c3a749"));

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "TEXT",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "TEXT",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "TEXT",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200);

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Provider = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    ProviderIdentityKey = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("03906db3-dd4d-4b31-a1e6-f2f66bff455f"), "3c919c5b-9eea-441d-8f35-6c4a6bdce456", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Flagg" },
                    { new Guid("103e10d8-29a9-46ba-91b4-3fa7db2f50cd"), "bcc3b61c-9529-4bd5-a4f3-2a0f3bfd705a", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "be" },
                    { new Guid("52e653ae-dd2b-44fa-804d-7222eb46a8a0"), "0bbf0f85-611b-4b2d-a181-20741b61d7ca", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Emma" },
                    { new Guid("7662d4e4-7cc3-48a9-8474-0c7aa5ff6688"), "8a111a7d-dd39-411e-929e-79ef2948f51c", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "nl" },
                    { new Guid("8f7b06e4-a134-43ae-9860-3cd00c5411c7"), "9d45e816-9140-4a44-87e5-5376b8bf0702", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "David" },
                    { new Guid("a532ff5d-379a-4c50-bb80-4ebf0536dd3f"), "b5e826bc-809f-4e14-9816-a92589eb5402", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Flagg" },
                    { new Guid("b740b017-acad-417f-bbe0-1a58b29834cc"), "49d6ef4f-22d0-464e-9b7d-90460b51f5dd", "role", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "FreeUser" },
                    { new Guid("d5986c34-c780-46e8-af6c-45c7884470f8"), "86ce4fe7-bdee-482b-963b-17457f0e8f7c", "role", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "PayingUser" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                column: "ConcurrencyStamp",
                value: "bb3ce251-3646-43fe-a090-ed6b25bc1794");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                column: "ConcurrencyStamp",
                value: "6aec844d-2713-4681-8bd0-9844abb37d79");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("03906db3-dd4d-4b31-a1e6-f2f66bff455f"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("103e10d8-29a9-46ba-91b4-3fa7db2f50cd"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("52e653ae-dd2b-44fa-804d-7222eb46a8a0"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("7662d4e4-7cc3-48a9-8474-0c7aa5ff6688"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("8f7b06e4-a134-43ae-9860-3cd00c5411c7"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("a532ff5d-379a-4c50-bb80-4ebf0536dd3f"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("b740b017-acad-417f-bbe0-1a58b29834cc"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("d5986c34-c780-46e8-af6c-45c7884470f8"));

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("06269e8c-6c23-4406-b87b-42269c6545d3"), "3e90c904-515a-4ffe-a77d-33f466040a05", "role", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "PayingUser" },
                    { new Guid("22244a3e-6c60-4b14-9778-03b6ed13f717"), "cccbc551-a233-4166-87fe-19f58bfc5744", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "be" },
                    { new Guid("272a478c-0630-47e0-ac65-609c5efd6fb1"), "aab49b70-b3d6-44a8-adbf-00e97d7f13c9", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Flagg" },
                    { new Guid("32e7e057-f081-4a47-8c86-eda16fec5cc9"), "4b2e3ada-b3b0-437d-a57a-26c4a785e836", "role", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "FreeUser" },
                    { new Guid("68966e98-1c93-4b2b-a844-09b650d408e0"), "10d7427d-3346-4a0b-877c-438d60fffb0f", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Flagg" },
                    { new Guid("6b2ca7fe-adbf-42af-9d67-d379b4791baa"), "aa2d6694-fe28-42d6-8c29-e4196c43e76d", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Emma" },
                    { new Guid("b5366b41-5efc-41bd-8617-eec1eda5582c"), "32a319f9-a997-456e-8c81-d668c9c65c9e", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "David" },
                    { new Guid("b8c8ec03-6a27-44da-a34f-c2d470c3a749"), "91352813-0bb8-4dac-8bac-c4e185e61bbe", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "nl" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                column: "ConcurrencyStamp",
                value: "4cdc9cba-3059-419b-a3cf-62802b12ef7c");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                column: "ConcurrencyStamp",
                value: "6b5b2568-42d6-47f6-a756-b1ddac075806");
        }
    }
}
