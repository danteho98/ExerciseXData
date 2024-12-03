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
                    DF_Serving_Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DF_Recommended_Servings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DF_Frequency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DF_Total_Calories = table.Column<int>(type: "int", nullable: true),
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
                    { 1, null, null, null, null, new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(5973), "Mediterranean Diet", null, null, null },
                    { 2, null, null, null, null, new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(5981), "Keto Diet", null, null, null },
                    { 3, null, null, null, null, new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6018), "Vegetarian Diet", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "F_Id", "F_Calories", "F_Group", "F_Image", "F_Modified_Date", "F_Name" },
                values: new object[,]
                {
                    { 1, 160, "Fruit", null, new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6111), "Avocado" },
                    { 2, 94, "Protein", null, new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6113), "Tofu" },
                    { 3, 115, "Legume", null, new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6114), "Lentils" },
                    { 4, 135, "Legume", null, new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6115), "Chickpeas" },
                    { 5, 222, "Grain", null, new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6116), "Quinoa" },
                    { 6, 41, "Vegetable", null, new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6117), "Spinach" },
                    { 7, 160, "Nut", null, new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6118), "Almonds" },
                    { 8, 112, "Vegetable", null, new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6119), "Sweet Potatoes" },
                    { 9, 55, "Vegetable", null, new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6120), "Broccoli" },
                    { 10, 25, "Vegetable", null, new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6121), "Carrots" },
                    { 11, 120, "Oil", null, new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6122), "Avocado Oil" },
                    { 12, 120, "Legume", null, new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6123), "Edamame" },
                    { 13, 138, "Seed", null, new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6125), "Chia Seeds" },
                    { 14, 8, "Vegetable", null, new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6126), "Cucumbers" },
                    { 15, 35, "Vegetable", null, new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6127), "Mushrooms" },
                    { 16, 100, "Dairy", null, new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6128), "Greek Yogurt" }
                });

            migrationBuilder.InsertData(
                table: "DietsFoods",
                columns: new[] { "DietsD_Id", "FoodsF_Id", "DF_Frequency", "DF_Modified_Date", "DF_Recommended_Servings", "DF_Serving_Size", "DF_Total_Calories" },
                values: new object[,]
                {
                    { 1, 1, "Daily", new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6158), "2-3 servings/day", "1 tablespoon", 119 },
                    { 1, 2, "Weekly", new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6160), "2-3 servings/week", "4 oz", 232 },
                    { 1, 3, "Daily", new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6162), "1-2 servings/day", "1 cup", 222 },
                    { 1, 4, "Daily", new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6164), "1-2 servings/day", "1 cup cooked", 41 },
                    { 1, 5, "Daily", new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6166), "1-2 servings/day", "1 cup", 60 },
                    { 1, 6, "Weekly", new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6168), "3-4 servings/week", "1/2 cup cooked", 134 },
                    { 1, 7, "Daily", new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6169), "1-2 servings/day", "1 ounce", 160 },
                    { 1, 8, "Daily", new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6171), "1-2 servings/day", "1 teaspoon dried", 3 },
                    { 1, 9, "Daily", new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6173), "1-2 servings/day", "1/2 cup", 100 },
                    { 1, 10, "Daily", new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6175), "1 serving/day", "5 oz", 125 },
                    { 2, 1, "Daily", new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6177), "1 serving/day", "1/2 avocado", 160 },
                    { 2, 2, "Daily", new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6178), "3-4 servings/day", "1 large egg", 72 },
                    { 2, 3, "Daily", new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6180), "1-2 servings/day", "4 oz", 187 },
                    { 2, 4, "Daily", new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6182), "1-2 servings/day", "2 slices", 80 },
                    { 2, 5, "Daily", new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6184), "2-3 servings/day", "1 oz", 115 },
                    { 2, 6, "Daily", new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6186), "2-3 servings/day", "1 tablespoon", 119 },
                    { 2, 7, "Daily", new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6187), "1 serving/day", "1 ounce", 160 },
                    { 2, 8, "Weekly", new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6189), "2-3 servings/week", "4 oz", 232 },
                    { 2, 9, "Daily", new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6191), "2-3 servings/day", "1 cup", 25 },
                    { 2, 10, "Daily", new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6193), "1-2 servings/day", "1 medium zucchini", 33 },
                    { 2, 11, "Daily", new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6195), "1-2 servings/day", "1 cup cooked", 41 },
                    { 2, 12, "Daily", new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6197), "1-2 servings/day", "1 tablespoon", 117 },
                    { 2, 13, "Daily", new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6198), "1 serving/day", "1 oz", 170 },
                    { 2, 14, "Daily", new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6200), "1-2 servings/day", "1 cup cooked", 35 },
                    { 2, 15, "Daily", new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6202), "1-2 servings/day", "2 tablespoons", 138 },
                    { 3, 1, "Daily", new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6204), "1 serving/day", "1/2 avocado", 160 },
                    { 3, 2, "Daily", new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6206), "1-2 servings/day", "4 oz", 94 },
                    { 3, 3, "Daily", new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6207), "2-3 servings/day", "1/2 cup cooked", 115 },
                    { 3, 4, "Daily", new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6209), "1-2 servings/day", "1/2 cup cooked", 135 },
                    { 3, 5, "Daily", new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6211), "1-2 servings/day", "1 cup cooked", 222 },
                    { 3, 6, "Daily", new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6213), "1-2 servings/day", "1 cup cooked", 41 },
                    { 3, 7, "Daily", new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6215), "1 serving/day", "1 ounce", 160 },
                    { 3, 8, "Daily", new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6216), "1 serving/day", "1 medium potato", 112 },
                    { 3, 9, "Daily", new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6218), "1-2 servings/day", "1 cup cooked", 55 },
                    { 3, 10, "Daily", new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6220), "1-2 servings/day", "1 medium carrot", 25 },
                    { 3, 11, "Daily", new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6222), "1-2 servings/day", "1 tablespoon", 120 },
                    { 3, 12, "Daily", new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6224), "1-2 servings/day", "1/2 cup", 120 },
                    { 3, 13, "Daily", new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6225), "1 serving/day", "2 tablespoons", 138 },
                    { 3, 14, "Daily", new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6227), "1-2 servings/day", "1/2 cucumber", 8 },
                    { 3, 15, "Daily", new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6229), "1-2 servings/day", "1 cup cooked", 35 },
                    { 3, 16, "Daily", new DateTime(2024, 12, 3, 8, 31, 29, 60, DateTimeKind.Local).AddTicks(6231), "1 serving/day", "1/2 cup", 100 }
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
