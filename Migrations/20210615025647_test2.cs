using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Crud_FP.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flowpoint_Support_Companies",
                columns: table => new
                {
                    ICompanyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VCompanyName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    VStreet1 = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    VStreet2 = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    VCity = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    VProvince = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VPostalCode = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    VCountry = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VContact = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    VPhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VFax = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DtCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BlsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flowpoint_Support_Companies", x => x.ICompanyID);
                });

            migrationBuilder.CreateTable(
                name: "Flowpoint_Support_Vendors",
                columns: table => new
                {
                    IVendorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VVendorName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    VStreet1 = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    VStreet2 = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    VCity = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    VProvince = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VPostalCode = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    VCountry = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VContact = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    VPhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VFax = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DtCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BlsActive = table.Column<bool>(type: "bit", nullable: false),
                    ICompanyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flowpoint_Support_Vendors", x => x.IVendorID);
                    table.ForeignKey(
                        name: "FK_Flowpoint_Support_Vendors_Flowpoint_Support_Companies_ICompanyID",
                        column: x => x.ICompanyID,
                        principalTable: "Flowpoint_Support_Companies",
                        principalColumn: "ICompanyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flowpoint_Support_Tickets",
                columns: table => new
                {
                    ITicketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VTicketMessage = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
                    DtCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ICreatedBy = table.Column<int>(type: "int", nullable: false),
                    IModifiedBy = table.Column<int>(type: "int", nullable: false),
                    BlsActive = table.Column<bool>(type: "bit", nullable: false),
                    IVendorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flowpoint_Support_Tickets", x => x.ITicketID);
                    table.ForeignKey(
                        name: "FK_Flowpoint_Support_Tickets_Flowpoint_Support_Vendors_IVendorID",
                        column: x => x.IVendorID,
                        principalTable: "Flowpoint_Support_Vendors",
                        principalColumn: "IVendorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flowpoint_Support_Tickets_IVendorID",
                table: "Flowpoint_Support_Tickets",
                column: "IVendorID");

            migrationBuilder.CreateIndex(
                name: "IX_Flowpoint_Support_Vendors_ICompanyID",
                table: "Flowpoint_Support_Vendors",
                column: "ICompanyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flowpoint_Support_Tickets");

            migrationBuilder.DropTable(
                name: "Flowpoint_Support_Vendors");

            migrationBuilder.DropTable(
                name: "Flowpoint_Support_Companies");
        }
    }
}
