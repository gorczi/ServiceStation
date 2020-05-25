using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceStation.Migrations
{
    public partial class AddAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressLine1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AddressLine2",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "AddressDataId",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddressDataId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressDataId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    AddressLine1 = table.Column<string>(maxLength: 100, nullable: false),
                    ZipCode = table.Column<string>(maxLength: 10, nullable: false),
                    City = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressDataId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AddressDataId",
                table: "Orders",
                column: "AddressDataId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AddressDataId",
                table: "AspNetUsers",
                column: "AddressDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressDataId",
                table: "AspNetUsers",
                column: "AddressDataId",
                principalTable: "Addresses",
                principalColumn: "AddressDataId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_AddressDataId",
                table: "Orders",
                column: "AddressDataId",
                principalTable: "Addresses",
                principalColumn: "AddressDataId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressDataId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_AddressDataId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AddressDataId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AddressDataId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AddressDataId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AddressDataId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine1",
                table: "Orders",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine2",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Orders",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Orders",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Orders",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
