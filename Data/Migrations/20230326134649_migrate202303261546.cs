using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aurora.Data.Migrations
{
    /// <inheritdoc />
    public partial class migrate202303261546 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuroraModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AcceptStatus = table.Column<bool>(type: "bit", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobLength = table.Column<int>(type: "int", nullable: false),
                    JobWorkers = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeLength = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobHidden = table.Column<bool>(type: "bit", nullable: false),
                    JobDone = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuroraModel", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuroraModel");
        }
    }
}
