using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExerciseXData_ExerciseLibrary.Migrations
{
    /// <inheritdoc />
    public partial class RenameCategoriesModelTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_CategoriesModel_CategoriesC_Id",
                table: "Exercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoriesModel",
                table: "CategoriesModel");

            migrationBuilder.RenameTable(
                name: "CategoriesModel",
                newName: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "C_Id");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "C_Id",
                keyValue: 1,
                column: "C_Modified_Date",
                value: new DateTime(2024, 11, 30, 7, 50, 51, 556, DateTimeKind.Local).AddTicks(6866));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "C_Id",
                keyValue: 2,
                column: "C_Modified_Date",
                value: new DateTime(2024, 11, 30, 7, 50, 51, 556, DateTimeKind.Local).AddTicks(6868));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "E_Id",
                keyValue: 1,
                column: "E_Modified_Date",
                value: new DateTime(2024, 11, 30, 7, 50, 51, 556, DateTimeKind.Local).AddTicks(6985));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "E_Id",
                keyValue: 2,
                column: "E_Modified_Date",
                value: new DateTime(2024, 11, 30, 7, 50, 51, 556, DateTimeKind.Local).AddTicks(6986));

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Categories_CategoriesC_Id",
                table: "Exercises",
                column: "CategoriesC_Id",
                principalTable: "Categories",
                principalColumn: "C_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Categories_CategoriesC_Id",
                table: "Exercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "CategoriesModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoriesModel",
                table: "CategoriesModel",
                column: "C_Id");

            migrationBuilder.UpdateData(
                table: "CategoriesModel",
                keyColumn: "C_Id",
                keyValue: 1,
                column: "C_Modified_Date",
                value: new DateTime(2024, 11, 29, 17, 21, 14, 775, DateTimeKind.Local).AddTicks(114));

            migrationBuilder.UpdateData(
                table: "CategoriesModel",
                keyColumn: "C_Id",
                keyValue: 2,
                column: "C_Modified_Date",
                value: new DateTime(2024, 11, 29, 17, 21, 14, 775, DateTimeKind.Local).AddTicks(116));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "E_Id",
                keyValue: 1,
                column: "E_Modified_Date",
                value: new DateTime(2024, 11, 29, 17, 21, 14, 775, DateTimeKind.Local).AddTicks(196));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "E_Id",
                keyValue: 2,
                column: "E_Modified_Date",
                value: new DateTime(2024, 11, 29, 17, 21, 14, 775, DateTimeKind.Local).AddTicks(197));

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_CategoriesModel_CategoriesC_Id",
                table: "Exercises",
                column: "CategoriesC_Id",
                principalTable: "CategoriesModel",
                principalColumn: "C_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
