using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExerciseXData_ExerciseLibrary.Migrations
{
    /// <inheritdoc />
    public partial class NewExercise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    C_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    C_Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    C_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    C_Modified_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.C_Id);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    E_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriesC_Id = table.Column<int>(type: "int", nullable: false),
                    E_Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    E_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    E_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    E_Pros_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    E_Pros_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    E_Pros_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    E_Cons_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    E_Cons_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    E_Cons_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    E_Modified_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.E_Id);
                    table.ForeignKey(
                        name: "FK_Exercises_Categories_CategoriesC_Id",
                        column: x => x.CategoriesC_Id,
                        principalTable: "Categories",
                        principalColumn: "C_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "C_Id", "C_Image", "C_Modified_Date", "C_Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 12, 1, 7, 51, 53, 139, DateTimeKind.Local).AddTicks(1498), "Cardio" },
                    { 2, null, new DateTime(2024, 12, 1, 7, 51, 53, 139, DateTimeKind.Local).AddTicks(1499), "Strength" }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "E_Id", "CategoriesC_Id", "E_Cons_1", "E_Cons_2", "E_Cons_3", "E_Description", "E_Image", "E_Modified_Date", "E_Name", "E_Pros_1", "E_Pros_2", "E_Pros_3" },
                values: new object[,]
                {
                    { 1, 1, null, null, null, null, null, new DateTime(2024, 12, 1, 7, 51, 53, 139, DateTimeKind.Local).AddTicks(1627), "Running", null, null, null },
                    { 2, 2, null, null, null, null, null, new DateTime(2024, 12, 1, 7, 51, 53, 139, DateTimeKind.Local).AddTicks(1629), "Push-ups", null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_CategoriesC_Id",
                table: "Exercises",
                column: "CategoriesC_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
