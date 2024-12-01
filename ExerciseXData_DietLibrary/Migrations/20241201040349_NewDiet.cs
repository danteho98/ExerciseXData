using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExerciseXData_DietLibrary.Migrations
{
    /// <inheritdoc />
    public partial class NewDiet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diets",
                columns: table => new
                {
                    D_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    D_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    D_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    D_Pros_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    D_Pros_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    D_Pros_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    D_Cons_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    D_Cons_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    D_Cons_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    D_Modified_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diets", x => x.D_Id);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    F_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    F_Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    F_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F_Group = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F_Calories = table.Column<int>(type: "int", nullable: true),
                    F_Modified_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.F_Id);
                });

            migrationBuilder.CreateTable(
                name: "DietsFoods",
                columns: table => new
                {
                    DietsD_Id = table.Column<int>(type: "int", nullable: false),
                    FoodsF_Id = table.Column<int>(type: "int", nullable: false),
                    DF_Id = table.Column<int>(type: "int", nullable: false),
                    DF_Serving_Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DF_Recommended_Servings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DF_Frequency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DF_Total_Calories = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DF_Modified_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietsFoods", x => new { x.DietsD_Id, x.FoodsF_Id });
                    table.ForeignKey(
                        name: "FK_DietsFoods_Diets_DietsD_Id",
                        column: x => x.DietsD_Id,
                        principalTable: "Diets",
                        principalColumn: "D_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DietsFoods_Foods_FoodsF_Id",
                        column: x => x.FoodsF_Id,
                        principalTable: "Foods",
                        principalColumn: "F_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Diets",
                columns: new[] { "D_Id", "D_Cons_1", "D_Cons_2", "D_Cons_3", "D_Description", "D_Modified_Date", "D_Name", "D_Pros_1", "D_Pros_2", "D_Pros_3" },
                values: new object[,]
                {
                    { 1, null, null, null, null, new DateTime(2024, 12, 1, 12, 3, 49, 409, DateTimeKind.Local).AddTicks(9189), "Keto Diet", null, null, null },
                    { 2, null, null, null, null, new DateTime(2024, 12, 1, 12, 3, 49, 409, DateTimeKind.Local).AddTicks(9197), "Mediterranean Diet", null, null, null },
                    { 3, null, null, null, null, new DateTime(2024, 12, 1, 12, 3, 49, 409, DateTimeKind.Local).AddTicks(9197), "Vegetarian Diet", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "F_Id", "F_Calories", "F_Group", "F_Image", "F_Modified_Date", "F_Name" },
                values: new object[,]
                {
                    { 1, 160, null, null, new DateTime(2024, 12, 1, 12, 3, 49, 409, DateTimeKind.Local).AddTicks(9302), "Avocado" },
                    { 2, 208, null, null, new DateTime(2024, 12, 1, 12, 3, 49, 409, DateTimeKind.Local).AddTicks(9303), "Salmon" },
                    { 3, 208, null, null, new DateTime(2024, 12, 1, 12, 3, 49, 409, DateTimeKind.Local).AddTicks(9304), "Broccoli " },
                    { 4, 161, null, null, new DateTime(2024, 12, 1, 12, 3, 49, 409, DateTimeKind.Local).AddTicks(9305), "Potato " },
                    { 5, 216, null, null, new DateTime(2024, 12, 1, 12, 3, 49, 409, DateTimeKind.Local).AddTicks(9306), "Brown rice" },
                    { 6, 205, null, null, new DateTime(2024, 12, 1, 12, 3, 49, 409, DateTimeKind.Local).AddTicks(9307), "White rice" },
                    { 7, 76, null, null, new DateTime(2024, 12, 1, 12, 3, 49, 409, DateTimeKind.Local).AddTicks(9308), "Tofu " },
                    { 8, 72, null, null, new DateTime(2024, 12, 1, 12, 3, 49, 409, DateTimeKind.Local).AddTicks(9309), "Egg" },
                    { 9, 271, null, null, new DateTime(2024, 12, 1, 12, 3, 49, 409, DateTimeKind.Local).AddTicks(9310), "Beef steak " },
                    { 10, 165, null, null, new DateTime(2024, 12, 1, 12, 3, 49, 409, DateTimeKind.Local).AddTicks(9311), "Chicken breast " },
                    { 11, 271, null, null, new DateTime(2024, 12, 1, 12, 3, 49, 409, DateTimeKind.Local).AddTicks(9312), "Beef steak " },
                    { 12, 95, null, null, new DateTime(2024, 12, 1, 12, 3, 49, 409, DateTimeKind.Local).AddTicks(9313), "Yogurt  " }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DietsFoods_FoodsF_Id",
                table: "DietsFoods",
                column: "FoodsF_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DietsFoods");

            migrationBuilder.DropTable(
                name: "Diets");

            migrationBuilder.DropTable(
                name: "Foods");
        }
    }
}
