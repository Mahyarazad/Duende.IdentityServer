using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IdentityServer.Migrations
{
    /// <inheritdoc />
    public partial class AddSecurityCodeExpiration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "SecurityExpirationDate",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("501aef6d-d09f-4d18-9435-ef7c458c2474"), "670e59c5-0484-4736-9fd6-95c05737d290", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "nl" },
                    { new Guid("743a7598-925e-4b34-a658-bdf679aa85bf"), "03bd57e4-2df4-48f6-a9a1-585a7e7b569e", "role", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "FreeUser" },
                    { new Guid("878b1331-4c9c-42f5-96b7-f7ccc5213f18"), "b469cd3f-b9e4-4c24-b405-a63f810e2b8b", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Flagg" },
                    { new Guid("c4d4b5c2-05ae-4798-beff-406608d4ae4b"), "5167add5-141a-4459-b5f2-10d486c7ceeb", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Flagg" },
                    { new Guid("c50531c0-eba9-4dc5-bfd2-fee5d3070de0"), "ad68e967-92a1-4729-90f4-3fd61f75b716", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "David" },
                    { new Guid("dd40d1c2-807e-443c-abcb-fc0e9554babf"), "3499901b-4b15-4ce2-95d6-7b2ce1dfd2f1", "role", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "PayingUser" },
                    { new Guid("e2da47e4-8193-474d-9533-e1d5c72d1ddd"), "08525763-6982-436a-9609-4c6d9808ad77", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Emma" },
                    { new Guid("e3658025-e19b-4a2f-8dbf-383d3743fbc4"), "de575058-9cb6-419b-9940-77dfdacd85af", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "be" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                columns: new[] { "ConcurrencyStamp", "SecurityExpirationDate" },
                values: new object[] { "891432dd-4e72-4cc5-8de0-abffbe74cf18", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                columns: new[] { "ConcurrencyStamp", "SecurityExpirationDate" },
                values: new object[] { "7e202309-a300-423c-87fb-ab235bbeadf9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("501aef6d-d09f-4d18-9435-ef7c458c2474"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("743a7598-925e-4b34-a658-bdf679aa85bf"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("878b1331-4c9c-42f5-96b7-f7ccc5213f18"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("c4d4b5c2-05ae-4798-beff-406608d4ae4b"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("c50531c0-eba9-4dc5-bfd2-fee5d3070de0"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("dd40d1c2-807e-443c-abcb-fc0e9554babf"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("e2da47e4-8193-474d-9533-e1d5c72d1ddd"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("e3658025-e19b-4a2f-8dbf-383d3743fbc4"));

            migrationBuilder.DropColumn(
                name: "SecurityExpirationDate",
                table: "Users");

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
                column: "ConcurrencyStamp",
                value: "bd7e3dee-6c77-48f4-b39f-11f6fccf9852");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                column: "ConcurrencyStamp",
                value: "3a31cda5-a2fc-4afd-86cc-76dae98182c3");
        }
    }
}
