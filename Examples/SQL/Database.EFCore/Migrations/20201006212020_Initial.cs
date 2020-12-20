using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Database.EFCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdvertType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Summary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Advert",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    PhotoUrl = table.Column<string>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advert", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Advert_AdvertType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "AdvertType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AdvertType",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Buy" },
                    { 2, "Sell" }
                });

            migrationBuilder.InsertData(
                table: "Advert",
                columns: new[] { "Id", "TypeId", "Name", "PhotoUrl", "TimeStamp", "Price" },
                values: new object[,]
                {
                    { 1, 2, "CyberPank 2077","", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2077 },
                    { 2, 2, "1 btc","", new DateTime(2020, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),  1700000 },
                    { 3, 1, "Box of pineapples","", new DateTime(2020, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),  1500 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advert_TypeId",
                table: "Advert",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advert"
            );

            migrationBuilder.DropTable(
                name: "AdvertType"
            );
        }
    }
}
