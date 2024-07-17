using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IdentityServer.Migrations
{
    /// <inheritdoc />
    public partial class UserSecrets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("28ac12a0-2532-4570-b844-c3347683f5c3"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("2ccfec6c-5b73-4de6-81fb-f2e83d94b9e2"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("5764896d-5c8d-48c5-a0f3-36dd3f5235fa"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("983a6837-e91a-49fc-8daa-e305b3709b28"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("ac3a9f47-90bf-43ec-bb8f-a085263ee43e"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("b4187bea-31e7-4683-b3c3-3984a97afeb4"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("cd1cf544-635c-4e4c-bf5f-9b1bd39980e9"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("ede97122-2b9e-42f3-9ada-71a56540b634"));

            migrationBuilder.CreateTable(
                name: "UserSecrets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Secret = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSecrets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSecrets_Users_UserId",
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

            migrationBuilder.CreateIndex(
                name: "IX_UserSecrets_UserId",
                table: "UserSecrets",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSecrets");

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

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("28ac12a0-2532-4570-b844-c3347683f5c3"), "ead59c1b-22f4-4c72-9826-f4100557ec93", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "be" },
                    { new Guid("2ccfec6c-5b73-4de6-81fb-f2e83d94b9e2"), "e41a9717-37f9-4b1b-a931-3acf6dcc8e1c", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Emma" },
                    { new Guid("5764896d-5c8d-48c5-a0f3-36dd3f5235fa"), "ace3ef37-86e5-46e0-88fe-b10162953f73", "role", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "FreeUser" },
                    { new Guid("983a6837-e91a-49fc-8daa-e305b3709b28"), "05b12a61-8cd2-4ccb-a243-1c91860bdd23", "role", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "PayingUser" },
                    { new Guid("ac3a9f47-90bf-43ec-bb8f-a085263ee43e"), "a5b92dc3-17dd-4379-9b79-c9f389218832", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "David" },
                    { new Guid("b4187bea-31e7-4683-b3c3-3984a97afeb4"), "f242fa62-890a-4bb5-80aa-551a019c0e0a", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Flagg" },
                    { new Guid("cd1cf544-635c-4e4c-bf5f-9b1bd39980e9"), "b3945135-9555-45c7-8f6a-9e547882011e", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Flagg" },
                    { new Guid("ede97122-2b9e-42f3-9ada-71a56540b634"), "f007e347-acd9-405c-aa22-a8348d2fd891", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "nl" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                column: "ConcurrencyStamp",
                value: "5ee6896d-18e7-4098-a389-186f99b52cc8");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                column: "ConcurrencyStamp",
                value: "2467cce3-cbbe-4fac-a3f2-13ad271b8145");
        }
    }
}
