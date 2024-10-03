using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibTrack.Migrations
{
    /// <inheritdoc />
    public partial class suces : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book_Tables",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RentPerDay = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book_Tables", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "User_tbles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_tbles", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Transcation_Tbles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalRent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transcation_Tbles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transcation_Tbles_Book_Tables_BookId",
                        column: x => x.BookId,
                        principalTable: "Book_Tables",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transcation_Tbles_User_tbles_UserId",
                        column: x => x.UserId,
                        principalTable: "User_tbles",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transcation_Tbles_BookId",
                table: "Transcation_Tbles",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Transcation_Tbles_UserId",
                table: "Transcation_Tbles",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transcation_Tbles");

            migrationBuilder.DropTable(
                name: "Book_Tables");

            migrationBuilder.DropTable(
                name: "User_tbles");
        }
    }
}
