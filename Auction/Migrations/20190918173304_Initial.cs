using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Auction.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    phoneNumber = table.Column<string>(nullable: true),
                    registration = table.Column<DateTime>(nullable: false),
                    login = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    admin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Lot",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    desc = table.Column<string>(nullable: true),
                    year = table.Column<int>(nullable: false),
                    transmission = table.Column<int>(nullable: false),
                    engineVolume = table.Column<double>(nullable: false),
                    fuel = table.Column<int>(nullable: false),
                    body = table.Column<int>(nullable: false),
                    drive = table.Column<int>(nullable: false),
                    mileage = table.Column<long>(nullable: false),
                    price = table.Column<long>(nullable: false),
                    image = table.Column<string>(nullable: true),
                    exposing = table.Column<DateTime>(nullable: false),
                    ending = table.Column<DateTime>(nullable: false),
                    premium = table.Column<bool>(nullable: false),
                    userid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lot", x => x.id);
                    table.ForeignKey(
                        name: "FK_Lot_User_userid",
                        column: x => x.userid,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bid",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    time = table.Column<DateTime>(nullable: false),
                    increase = table.Column<long>(nullable: false),
                    lotid = table.Column<int>(nullable: true),
                    userid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bid", x => x.id);
                    table.ForeignKey(
                        name: "FK_Bid_Lot_lotid",
                        column: x => x.lotid,
                        principalTable: "Lot",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bid_User_userid",
                        column: x => x.userid,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bid_lotid",
                table: "Bid",
                column: "lotid");

            migrationBuilder.CreateIndex(
                name: "IX_Bid_userid",
                table: "Bid",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_Lot_userid",
                table: "Lot",
                column: "userid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bid");

            migrationBuilder.DropTable(
                name: "Lot");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
