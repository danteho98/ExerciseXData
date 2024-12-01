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
                    { 1, null, null, null, null, new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2692), "Mediterranean Diet", null, null, null },
                    { 2, null, null, null, null, new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2702), "Keto Diet", null, null, null },
                    { 3, null, null, null, null, new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2703), "Vegetarian Diet", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "F_Id", "F_Calories", "F_Group", "F_Image", "F_Modified_Date", "F_Name" },
                values: new object[,]
                {
                    { 1, 160, "Fruit", null, new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2786), "Avocado" },
                    { 2, 94, "Protein", null, new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2787), "Tofu" },
                    { 3, 115, "Legume", null, new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2788), "Lentils" },
                    { 4, 135, "Legume", null, new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2789), "Chickpeas" },
                    { 5, 222, "Grain", null, new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2790), "Quinoa" },
                    { 6, 41, "Vegetable", null, new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2792), "Spinach" },
                    { 7, 160, "Nut", null, new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2793), "Almonds" },
                    { 8, 112, "Vegetable", null, new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2794), "Sweet Potatoes" },
                    { 9, 55, "Vegetable", null, new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2795), "Broccoli" },
                    { 10, 25, "Vegetable", null, new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2796), "Carrots" },
                    { 11, 120, "Oil", null, new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2797), "Avocado Oil" },
                    { 12, 120, "Legume", null, new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2798), "Edamame" },
                    { 13, 138, "Seed", null, new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2799), "Chia Seeds" },
                    { 14, 8, "Vegetable", null, new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2800), "Cucumbers" },
                    { 15, 35, "Vegetable", null, new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2801), "Mushrooms" },
                    { 16, 100, "Dairy", null, new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2802), "Greek Yogurt" }
                });

            migrationBuilder.InsertData(
                table: "DietsFoods",
                columns: new[] { "DietsD_Id", "FoodsF_Id", "DF_Frequency", "DF_Modified_Date", "DF_Recommended_Servings", "DF_Serving_Size", "DF_Total_Calories" },
                values: new object[,]
                {
                    { 1, 1, "Daily", new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2832), "2-3 servings/day", "1 tablespoon", 119 },
                    { 1, 2, "Weekly", new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2834), "2-3 servings/week", "4 oz", 232 },
                    { 1, 3, "Daily", new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2836), "1-2 servings/day", "1 cup", 222 },
                    { 1, 4, "Daily", new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2838), "1-2 servings/day", "1 cup cooked", 41 },
                    { 1, 5, "Daily", new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2840), "1-2 servings/day", "1 cup", 60 },
                    { 1, 6, "Weekly", new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2842), "3-4 servings/week", "1/2 cup cooked", 134 },
                    { 1, 7, "Daily", new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2843), "1-2 servings/day", "1 ounce", 160 },
                    { 1, 8, "Daily", new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2845), "1-2 servings/day", "1 teaspoon dried", 3 },
                    { 1, 9, "Daily", new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2847), "1-2 servings/day", "1/2 cup", 100 },
                    { 1, 10, "Daily", new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2849), "1 serving/day", "5 oz", 125 },
                    { 2, 1, "Daily", new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2851), "1 serving/day", "1/2 avocado", 160 },
                    { 2, 2, "Daily", new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2853), "3-4 servings/day", "1 large egg", 72 },
                    { 2, 3, "Daily", new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2854), "1-2 servings/day", "4 oz", 187 },
                    { 2, 4, "Daily", new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2856), "1-2 servings/day", "2 slices", 80 },
                    { 2, 5, "Daily", new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2858), "2-3 servings/day", "1 oz", 115 },
                    { 2, 6, "Daily", new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2860), "2-3 servings/day", "1 tablespoon", 119 },
                    { 2, 7, "Daily", new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2862), "1 serving/day", "1 ounce", 160 },
                    { 2, 8, "Weekly", new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2863), "2-3 servings/week", "4 oz", 232 },
                    { 2, 9, "Daily", new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2865), "2-3 servings/day", "1 cup", 25 },
                    { 2, 10, "Daily", new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2867), "1-2 servings/day", "1 medium zucchini", 33 },
                    { 2, 11, "Daily", new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2872), "1-2 servings/day", "1 cup cooked", 41 },
                    { 2, 12, "Daily", new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2874), "1-2 servings/day", "1 tablespoon", 117 },
                    { 2, 13, "Daily", new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2876), "1 serving/day", "1 oz", 170 },
                    { 2, 14, "Daily", new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2878), "1-2 servings/day", "1 cup cooked", 35 },
                    { 2, 15, "Daily", new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2879), "1-2 servings/day", "2 tablespoons", 138 },
                    { 3, 1, "Daily", new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2881), "1 serving/day", "1/2 avocado", 160 },
                    { 3, 2, "Daily", new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2883), "1-2 servings/day", "4 oz", 94 },
                    { 3, 3, "Daily", new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2885), "2-3 servings/day", "1/2 cup cooked", 115 },
                    { 3, 4, "Daily", new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2887), "1-2 servings/day", "1/2 cup cooked", 135 },
                    { 3, 5, "Daily", new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2889), "1-2 servings/day", "1 cup cooked", 222 },
                    { 3, 6, "Daily", new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2890), "1-2 servings/day", "1 cup cooked", 41 },
                    { 3, 7, "Daily", new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2892), "1 serving/day", "1 ounce", 160 },
                    { 3, 8, "Daily", new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2894), "1 serving/day", "1 medium potato", 112 },
                    { 3, 9, "Daily", new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2896), "1-2 servings/day", "1 cup cooked", 55 },
                    { 3, 10, "Daily", new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2897), "1-2 servings/day", "1 medium carrot", 25 },
                    { 3, 11, "Daily", new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2899), "1-2 servings/day", "1 tablespoon", 120 },
                    { 3, 12, "Daily", new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2901), "1-2 servings/day", "1/2 cup", 120 },
                    { 3, 13, "Daily", new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2903), "1 serving/day", "2 tablespoons", 138 },
                    { 3, 14, "Daily", new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2905), "1-2 servings/day", "1/2 cucumber", 8 },
                    { 3, 15, "Daily", new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2907), "1-2 servings/day", "1 cup cooked", 35 },
                    { 3, 16, "Daily", new DateTime(2024, 12, 1, 15, 10, 13, 443, DateTimeKind.Local).AddTicks(2908), "1 serving/day", "1/2 cup", 100 }
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
