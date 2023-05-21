using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aurora.Data.Migrations
{
    /// <inheritdoc />
    public partial class Aurora1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "AuroraModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "AuroraModel",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AuroraModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "JobLength",
                table: "AuroraModel",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            //migrationBuilder.CreateTable(
            //    name: "AuroraModel2",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Date = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        JobLength = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Difficulty = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        JobWorkers = table.Column<int>(type: "int", nullable: false),
            //        Phone = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
            //        TimeLength = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        JobEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        JobHidden = table.Column<bool>(type: "bit", nullable: false),
            //        JobDone = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AuroraModel2", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "AuroraModel3",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobLength = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Difficulty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobWorkers = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    TimeLength = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobHidden = table.Column<bool>(type: "bit", nullable: false),
                    JobDone = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuroraModel3", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "Difficulty",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        DifficultyLevel = table.Column<int>(type: "int", nullable: false),
            //        DifficultyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Difficulty", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "jobLength",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Length = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_jobLength", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "timeLength",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Length = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Pricing = table.Column<double>(type: "float", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_timeLength", x => x.Id);
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuroraModel2");

            migrationBuilder.DropTable(
                name: "AuroraModel3");

            migrationBuilder.DropTable(
                name: "Difficulty");

            migrationBuilder.DropTable(
                name: "jobLength");

            migrationBuilder.DropTable(
                name: "timeLength");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "AuroraModel",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Phone",
                table: "AuroraModel",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(9)",
                oldMaxLength: 9);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AuroraModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "JobLength",
                table: "AuroraModel",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
