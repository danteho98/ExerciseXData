using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExerciseXData.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    C_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    C_Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    C_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    C_Modified_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.C_Id);
                });

            migrationBuilder.CreateTable(
                name: "DietFoods",
                columns: table => new
                {
                    DF_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    D_ID = table.Column<int>(type: "int", nullable: true),
                    F_Id = table.Column<int>(type: "int", nullable: true),
                    DF_Modified_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietFoods", x => x.DF_Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    U_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    U_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Height = table.Column<double>(type: "float", nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: true),
                    Lifestyle_Condition_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lifestyle_Condition_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lifestyle_Condition_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lifestyle_Condition_4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lifestyle_Condition_5 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.U_Id);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    E_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    C_Id = table.Column<int>(type: "int", nullable: false),
                    CategoryC_Id = table.Column<int>(type: "int", nullable: false),
                    E_Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                        name: "FK_Exercises_Categories_CategoryC_Id",
                        column: x => x.CategoryC_Id,
                        principalTable: "Categories",
                        principalColumn: "C_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diets",
                columns: table => new
                {
                    D_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    D_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    D_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F_Amount = table.Column<int>(type: "int", nullable: true),
                    D_Total_Calories = table.Column<int>(type: "int", nullable: true),
                    D_Pros_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    D_Pros_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    D_Pros_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    D_Cons_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    D_Cons_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    D_Cons_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    D_Modified_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DietsFoodsDF_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diets", x => x.D_Id);
                    table.ForeignKey(
                        name: "FK_Diets_DietFoods_DietsFoodsDF_Id",
                        column: x => x.DietsFoodsDF_Id,
                        principalTable: "DietFoods",
                        principalColumn: "DF_Id");
                });

            migrationBuilder.CreateTable(
                name: "UserExercises",
                columns: table => new
                {
                    UE_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    U_Id = table.Column<int>(type: "int", nullable: false),
                    UserU_Id = table.Column<int>(type: "int", nullable: false),
                    E_Id = table.Column<int>(type: "int", nullable: false),
                    ExerciseE_Id = table.Column<int>(type: "int", nullable: false),
                    Times_Performed = table.Column<int>(type: "int", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: true),
                    UE_Modify_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExercises", x => x.UE_Id);
                    table.ForeignKey(
                        name: "FK_UserExercises_Exercises_ExerciseE_Id",
                        column: x => x.ExerciseE_Id,
                        principalTable: "Exercises",
                        principalColumn: "E_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserExercises_Users_UserU_Id",
                        column: x => x.UserU_Id,
                        principalTable: "Users",
                        principalColumn: "U_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    F_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    F_Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F_Calories = table.Column<int>(type: "int", nullable: true),
                    F_Modified_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    D_Id = table.Column<int>(type: "int", nullable: false),
                    DietD_Id = table.Column<int>(type: "int", nullable: false),
                    DietsFoodsDF_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.F_Id);
                    table.ForeignKey(
                        name: "FK_Foods_DietFoods_DietsFoodsDF_Id",
                        column: x => x.DietsFoodsDF_Id,
                        principalTable: "DietFoods",
                        principalColumn: "DF_Id");
                    table.ForeignKey(
                        name: "FK_Foods_Diets_DietD_Id",
                        column: x => x.DietD_Id,
                        principalTable: "Diets",
                        principalColumn: "D_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDiets",
                columns: table => new
                {
                    UD_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    U_Id = table.Column<int>(type: "int", nullable: false),
                    UsersU_Id = table.Column<int>(type: "int", nullable: false),
                    D_Id = table.Column<int>(type: "int", nullable: false),
                    DietsD_Id = table.Column<int>(type: "int", nullable: false),
                    Food_Name = table.Column<int>(type: "int", nullable: true),
                    Food_Quantity = table.Column<int>(type: "int", nullable: true),
                    Food_Calories = table.Column<int>(type: "int", nullable: true),
                    Total_Calaroies = table.Column<int>(type: "int", nullable: true),
                    UD_Modified_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FoodsF_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDiets", x => x.UD_Id);
                    table.ForeignKey(
                        name: "FK_UserDiets_Diets_DietsD_Id",
                        column: x => x.DietsD_Id,
                        principalTable: "Diets",
                        principalColumn: "D_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDiets_Foods_FoodsF_Id",
                        column: x => x.FoodsF_Id,
                        principalTable: "Foods",
                        principalColumn: "F_Id");
                    table.ForeignKey(
                        name: "FK_UserDiets_Users_UsersU_Id",
                        column: x => x.UsersU_Id,
                        principalTable: "Users",
                        principalColumn: "U_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diets_DietsFoodsDF_Id",
                table: "Diets",
                column: "DietsFoodsDF_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_CategoryC_Id",
                table: "Exercises",
                column: "CategoryC_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_DietD_Id",
                table: "Foods",
                column: "DietD_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_DietsFoodsDF_Id",
                table: "Foods",
                column: "DietsFoodsDF_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserDiets_DietsD_Id",
                table: "UserDiets",
                column: "DietsD_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserDiets_FoodsF_Id",
                table: "UserDiets",
                column: "FoodsF_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserDiets_UsersU_Id",
                table: "UserDiets",
                column: "UsersU_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserExercises_ExerciseE_Id",
                table: "UserExercises",
                column: "ExerciseE_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserExercises_UserU_Id",
                table: "UserExercises",
                column: "UserU_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDiets");

            migrationBuilder.DropTable(
                name: "UserExercises");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Diets");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "DietFoods");
        }
    }
}
