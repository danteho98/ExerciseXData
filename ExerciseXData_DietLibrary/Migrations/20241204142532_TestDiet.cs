using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExerciseXData_DietLibrary.Migrations
{
    /// <inheritdoc />
    public partial class TestDiet : Migration
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
                    D_ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "UsersModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    U_Age = table.Column<int>(type: "int", nullable: false),
                    U_Height_CM = table.Column<double>(type: "float", nullable: false),
                    U_Weight_KG = table.Column<double>(type: "float", nullable: false),
                    DietaryPreferences = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    U_Created_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    U_Last_Login = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConsentToDataCollection = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersModel", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "UsersDiets",
                columns: table => new
                {
                    UD_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    D_Id = table.Column<int>(type: "int", nullable: false),
                    CustomDietName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UD_ServingSize = table.Column<int>(type: "int", nullable: true),
                    UD_Frequency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UD_TotalCalaroies = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    UD_Modified_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersDiets", x => x.UD_Id);
                    table.ForeignKey(
                        name: "FK_UsersDiets_Diets_D_Id",
                        column: x => x.D_Id,
                        principalTable: "Diets",
                        principalColumn: "D_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersDiets_UsersModel_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Diets",
                columns: new[] { "D_Id", "D_Cons_1", "D_Cons_2", "D_Cons_3", "D_Description", "D_ModifiedDate", "D_Name", "D_Pros_1", "D_Pros_2", "D_Pros_3" },
                values: new object[,]
                {
                    { 1, null, null, null, null, new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3569), "Mediterranean Diet", null, null, null },
                    { 2, null, null, null, null, new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3578), "Keto Diet", null, null, null },
                    { 3, null, null, null, null, new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3578), "Vegetarian Diet", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "F_Id", "F_Calories", "F_Group", "F_Image", "F_Modified_Date", "F_Name" },
                values: new object[,]
                {
                    { 1, 160, "Fruit", null, new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3697), "Avocado" },
                    { 2, 94, "Protein", null, new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3698), "Tofu" },
                    { 3, 115, "Legume", null, new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3699), "Lentils" },
                    { 4, 135, "Legume", null, new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3700), "Chickpeas" },
                    { 5, 222, "Grain", null, new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3701), "Quinoa" },
                    { 6, 41, "Vegetable", null, new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3702), "Spinach" },
                    { 7, 160, "Nut", null, new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3703), "Almonds" },
                    { 8, 112, "Vegetable", null, new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3704), "Sweet Potatoes" },
                    { 9, 55, "Vegetable", null, new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3705), "Broccoli" },
                    { 10, 25, "Vegetable", null, new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3706), "Carrots" },
                    { 11, 120, "Oil", null, new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3707), "Avocado Oil" },
                    { 12, 120, "Legume", null, new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3709), "Edamame" },
                    { 13, 138, "Seed", null, new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3710), "Chia Seeds" },
                    { 14, 8, "Vegetable", null, new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3779), "Cucumbers" },
                    { 15, 35, "Vegetable", null, new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3780), "Mushrooms" },
                    { 16, 100, "Dairy", null, new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3781), "Greek Yogurt" }
                });

            migrationBuilder.InsertData(
                table: "DietsFoods",
                columns: new[] { "DietsD_Id", "FoodsF_Id", "DF_Frequency", "DF_Modified_Date", "DF_Recommended_Servings", "DF_Serving_Size", "DF_Total_Calories" },
                values: new object[,]
                {
                    { 1, 1, "Daily", new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3812), "2-3 servings/day", "1 tablespoon", 119 },
                    { 1, 2, "Weekly", new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3814), "2-3 servings/week", "4 oz", 232 },
                    { 1, 3, "Daily", new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3816), "1-2 servings/day", "1 cup", 222 },
                    { 1, 4, "Daily", new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3818), "1-2 servings/day", "1 cup cooked", 41 },
                    { 1, 5, "Daily", new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3819), "1-2 servings/day", "1 cup", 60 },
                    { 1, 6, "Weekly", new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3821), "3-4 servings/week", "1/2 cup cooked", 134 },
                    { 1, 7, "Daily", new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3823), "1-2 servings/day", "1 ounce", 160 },
                    { 1, 8, "Daily", new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3825), "1-2 servings/day", "1 teaspoon dried", 3 },
                    { 1, 9, "Daily", new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3827), "1-2 servings/day", "1/2 cup", 100 },
                    { 1, 10, "Daily", new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3829), "1 serving/day", "5 oz", 125 },
                    { 2, 1, "Daily", new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3830), "1 serving/day", "1/2 avocado", 160 },
                    { 2, 2, "Daily", new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3832), "3-4 servings/day", "1 large egg", 72 },
                    { 2, 3, "Daily", new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3834), "1-2 servings/day", "4 oz", 187 },
                    { 2, 4, "Daily", new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3836), "1-2 servings/day", "2 slices", 80 },
                    { 2, 5, "Daily", new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3838), "2-3 servings/day", "1 oz", 115 },
                    { 2, 6, "Daily", new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3839), "2-3 servings/day", "1 tablespoon", 119 },
                    { 2, 7, "Daily", new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3841), "1 serving/day", "1 ounce", 160 },
                    { 2, 8, "Weekly", new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3843), "2-3 servings/week", "4 oz", 232 },
                    { 2, 9, "Daily", new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3845), "2-3 servings/day", "1 cup", 25 },
                    { 2, 10, "Daily", new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3847), "1-2 servings/day", "1 medium zucchini", 33 },
                    { 2, 11, "Daily", new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3848), "1-2 servings/day", "1 cup cooked", 41 },
                    { 2, 12, "Daily", new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3850), "1-2 servings/day", "1 tablespoon", 117 },
                    { 2, 13, "Daily", new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3852), "1 serving/day", "1 oz", 170 },
                    { 2, 14, "Daily", new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3854), "1-2 servings/day", "1 cup cooked", 35 },
                    { 2, 15, "Daily", new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3855), "1-2 servings/day", "2 tablespoons", 138 },
                    { 3, 1, "Daily", new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3857), "1 serving/day", "1/2 avocado", 160 },
                    { 3, 2, "Daily", new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3859), "1-2 servings/day", "4 oz", 94 },
                    { 3, 3, "Daily", new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3861), "2-3 servings/day", "1/2 cup cooked", 115 },
                    { 3, 4, "Daily", new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3863), "1-2 servings/day", "1/2 cup cooked", 135 },
                    { 3, 5, "Daily", new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3864), "1-2 servings/day", "1 cup cooked", 222 },
                    { 3, 6, "Daily", new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3866), "1-2 servings/day", "1 cup cooked", 41 },
                    { 3, 7, "Daily", new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3868), "1 serving/day", "1 ounce", 160 },
                    { 3, 8, "Daily", new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3870), "1 serving/day", "1 medium potato", 112 },
                    { 3, 9, "Daily", new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3872), "1-2 servings/day", "1 cup cooked", 55 },
                    { 3, 10, "Daily", new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3873), "1-2 servings/day", "1 medium carrot", 25 },
                    { 3, 11, "Daily", new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3875), "1-2 servings/day", "1 tablespoon", 120 },
                    { 3, 12, "Daily", new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3877), "1-2 servings/day", "1/2 cup", 120 },
                    { 3, 13, "Daily", new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3879), "1 serving/day", "2 tablespoons", 138 },
                    { 3, 14, "Daily", new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3881), "1-2 servings/day", "1/2 cucumber", 8 },
                    { 3, 15, "Daily", new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3883), "1-2 servings/day", "1 cup cooked", 35 },
                    { 3, 16, "Daily", new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3884), "1 serving/day", "1/2 cup", 100 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DietsFoods_FoodsF_Id",
                table: "DietsFoods",
                column: "FoodsF_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UsersDiets_D_Id",
                table: "UsersDiets",
                column: "D_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UsersDiets_UserId",
                table: "UsersDiets",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DietsFoods");

            migrationBuilder.DropTable(
                name: "UsersDiets");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Diets");

            migrationBuilder.DropTable(
                name: "UsersModel");
        }
    }
}
