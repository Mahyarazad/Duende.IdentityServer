using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IdentityServer.Migrations
{
    /// <inheritdoc />
    public partial class EmailNotNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("0c182b5c-f694-4690-bd27-814599c1b0c4"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("12296a58-81d9-4174-a7fd-eb40aec5cc8b"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("1f85a3cf-0acb-4554-b0eb-d6bc989180fb"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("2c16d211-4ca4-460a-b528-b3188d04f4d6"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("387fad4a-82e6-4ac1-8afa-ec2b25335504"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("50bdc0f5-8019-41f1-8fa6-2b2ff904ef90"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("784192d1-acef-4df8-8d13-568b7bded498"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("e69765a6-eab8-4fe1-99ce-324f92b7e6fa"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("0c182b5c-f694-4690-bd27-814599c1b0c4"), "d2a5c410-55ac-4e31-ae55-bfd0ba16426b", "role", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "FreeUser" },
                    { new Guid("12296a58-81d9-4174-a7fd-eb40aec5cc8b"), "c3782805-2dd7-4321-a0a8-965162040a76", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "David" },
                    { new Guid("1f85a3cf-0acb-4554-b0eb-d6bc989180fb"), "54a93d7f-9dc8-4653-a721-b4ce9c03b529", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Flagg" },
                    { new Guid("2c16d211-4ca4-460a-b528-b3188d04f4d6"), "603e72f5-30d8-442c-bd90-c0a3eb1b354d", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Flagg" },
                    { new Guid("387fad4a-82e6-4ac1-8afa-ec2b25335504"), "684ed7a2-5955-4f19-a262-29347793883b", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "be" },
                    { new Guid("50bdc0f5-8019-41f1-8fa6-2b2ff904ef90"), "623870a2-dd78-48e1-8106-124f4bc6f9bd", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Emma" },
                    { new Guid("784192d1-acef-4df8-8d13-568b7bded498"), "4f2b0fb9-b3fa-48f0-87f4-d1685dab2632", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "nl" },
                    { new Guid("e69765a6-eab8-4fe1-99ce-324f92b7e6fa"), "7af16a73-fc97-4aa4-8fc7-da1a71cee74b", "role", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "PayingUser" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                column: "ConcurrencyStamp",
                value: "bd574ead-a675-46a1-a677-dc951fcbe12d");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                column: "ConcurrencyStamp",
                value: "63bc3427-4a74-4483-ad62-c47c0a46d777");
        }
    }
}
