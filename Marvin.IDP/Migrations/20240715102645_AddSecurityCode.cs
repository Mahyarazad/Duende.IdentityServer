using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IdentityServer.Migrations
{
    /// <inheritdoc />
    public partial class AddSecurityCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("2f595e68-9f16-4b22-9942-63e16fdd77e0"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("45967fba-3a70-40ab-878e-f0f0e9aaddd1"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("67f1b00b-93c4-47b3-875f-8d1098ade6dd"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("68713764-76f9-4db9-9cba-913a5f7fa207"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("8bbfd9e7-97ab-4df3-8fa1-1edb1c8568ba"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("9901efb1-2491-49f4-ab2f-3c867c6d8ea8"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("bd400c29-4040-4b5b-95d1-46f7c778cfca"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("d464583f-939a-4200-b94b-6428dd074f31"));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecurityCode",
                table: "Users",
                type: "TEXT",
                maxLength: 200,
                nullable: true);

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("3d2e03cc-47cd-40e9-85d6-7597f0c7ad91"), "03d4b243-a21a-4a2f-b69d-1572aba28549", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Flagg" },
                    { new Guid("3db8dcc0-daae-490e-9798-8b6719db7efc"), "2c15344a-756f-4b31-8664-fae0ba45a72e", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Flagg" },
                    { new Guid("54d72ce8-63a0-4311-a1cc-1caf37d486e1"), "988f272f-409b-4876-b000-e621fe7308ed", "role", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "PayingUser" },
                    { new Guid("64768da5-e2cb-49b9-8a59-d79ff1fbe665"), "ecb025c8-fd5b-403e-b07f-699012aec918", "role", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "FreeUser" },
                    { new Guid("942d4356-cdd8-43cb-bdcd-410741c7bf13"), "30f2054a-57fd-4d13-8298-6ff3e46f868e", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "be" },
                    { new Guid("f699a6a2-6b57-40a0-9d73-58a9d8cd0330"), "9e0bdee3-10d5-424b-b3bb-adfa3bceebee", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Emma" },
                    { new Guid("f9e14eda-8bac-4c43-89f2-2b9bc532e406"), "1b21026c-4af9-4295-bfc2-4fe76eba8319", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "nl" },
                    { new Guid("fd1a640c-0f02-4914-87b5-52847899ffa4"), "3e3749d8-9f5d-4304-9139-638a589a42da", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "David" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                columns: new[] { "ConcurrencyStamp", "Email", "SecurityCode" },
                values: new object[] { "bd7e3dee-6c77-48f4-b39f-11f6fccf9852", "david@gamil.com", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                columns: new[] { "ConcurrencyStamp", "Email", "SecurityCode" },
                values: new object[] { "3a31cda5-a2fc-4afd-86cc-76dae98182c3", "emma@gamil.com", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("3d2e03cc-47cd-40e9-85d6-7597f0c7ad91"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("3db8dcc0-daae-490e-9798-8b6719db7efc"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("54d72ce8-63a0-4311-a1cc-1caf37d486e1"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("64768da5-e2cb-49b9-8a59-d79ff1fbe665"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("942d4356-cdd8-43cb-bdcd-410741c7bf13"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("f699a6a2-6b57-40a0-9d73-58a9d8cd0330"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("f9e14eda-8bac-4c43-89f2-2b9bc532e406"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("fd1a640c-0f02-4914-87b5-52847899ffa4"));

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SecurityCode",
                table: "Users");

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("2f595e68-9f16-4b22-9942-63e16fdd77e0"), "4afbcfff-918d-4bac-af8e-f0ea8d3d6e09", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Emma" },
                    { new Guid("45967fba-3a70-40ab-878e-f0f0e9aaddd1"), "bc5be4c4-a96d-452b-90a2-38ddf64b99b2", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Flagg" },
                    { new Guid("67f1b00b-93c4-47b3-875f-8d1098ade6dd"), "1e471e08-a55e-449d-a5c5-344c733ca9c8", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "be" },
                    { new Guid("68713764-76f9-4db9-9cba-913a5f7fa207"), "131235b1-051f-4280-b039-b83c8c107fe9", "role", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "FreeUser" },
                    { new Guid("8bbfd9e7-97ab-4df3-8fa1-1edb1c8568ba"), "14a43146-3707-47d0-8f20-739889e16c91", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "David" },
                    { new Guid("9901efb1-2491-49f4-ab2f-3c867c6d8ea8"), "1405e3d5-c922-43f0-852e-accfa92e7ea9", "role", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "PayingUser" },
                    { new Guid("bd400c29-4040-4b5b-95d1-46f7c778cfca"), "9f8d7b31-507d-4332-9300-a99ab746a9bd", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Flagg" },
                    { new Guid("d464583f-939a-4200-b94b-6428dd074f31"), "3ec3c99f-ff6c-43d0-a2b2-cca79780e62f", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "nl" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                column: "ConcurrencyStamp",
                value: "fd522e03-2a6b-436d-94c5-b3a8700550e1");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                column: "ConcurrencyStamp",
                value: "72269c04-a1fb-45bc-857b-1a7eadada6c7");
        }
    }
}
