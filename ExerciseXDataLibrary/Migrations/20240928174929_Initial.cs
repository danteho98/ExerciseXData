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
                    F_Image = table.Column<string>(type: "varbinary(max)", nullable: true),
                    F_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F_Calories = table.Column<int>(type: "int", nullable: true),
                    F_Modified_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.F_Id);
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
                    C_Id = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_Exercises_Categories_CategoriesC_Id",
                        column: x => x.C_Id,
                        principalTable: "Categories",
                        principalColumn: "C_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DietsFoods",
                columns: table => new
                {
                    D_Id = table.Column<int>(type: "int", nullable: false),
                    F_Id = table.Column<int>(type: "int", nullable: false),
                    DF_Id = table.Column<int>(type: "int", nullable: false),
                    DF_Modified_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietsFoods", x => new { x.D_Id, x.F_Id });
                    table.ForeignKey(
                        name: "FK_DietsFoods_Diets_D_Id",
                        column: x => x.D_Id,
                        principalTable: "Diets",
                        principalColumn: "D_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DietsFoods_Foods_F_Id",
                        column: x => x.F_Id,
                        principalTable: "Foods",
                        principalColumn: "F_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersDiets",
                columns: table => new
                {
                    U_Id = table.Column<int>(type: "int", nullable: false),
                    D_Id = table.Column<int>(type: "int", nullable: false),
                    UD_Id = table.Column<int>(type: "int", nullable: false),
                    Food_Name = table.Column<int>(type: "int", nullable: true),
                    Food_Quantity = table.Column<int>(type: "int", nullable: true),
                    Food_Calories = table.Column<int>(type: "int", nullable: true),
                    Total_Calaroies = table.Column<int>(type: "int", nullable: true),
                    UD_Modified_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersDiets", x => new { x.U_Id, x.D_Id });
                    table.ForeignKey(
                        name: "FK_UsersDiets_Diets_D_Id",
                        column: x => x.D_Id,
                        principalTable: "Diets",
                        principalColumn: "D_Id",
                        onDelete: ReferentialAction.Cascade);

                    table.ForeignKey(
                        name: "FK_UsersDiets_Users_U_Id",
                        column: x => x.U_Id,
                        principalTable: "Users",
                        principalColumn: "U_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersExercises",
                columns: table => new
                {
                    U_Id = table.Column<int>(type: "int", nullable: false),
                    E_Id = table.Column<int>(type: "int", nullable: false),
                    UE_Id = table.Column<int>(type: "int", nullable: false),
                    Repetition = table.Column<int>(type: "int", nullable: true),
                    Sets = table.Column<int>(type: "int", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: true),
                    UE_Modify_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersExercises", x => new { x.U_Id, x.E_Id });
                    table.ForeignKey(
                        name: "FK_UsersExercises_Exercises_E_Id",
                        column: x => x.E_Id,
                        principalTable: "Exercises",
                        principalColumn: "E_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersExercises_Users_U_Id",
                        column: x => x.U_Id,
                        principalTable: "Users",
                        principalColumn: "U_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DietsFoods_F_Id",
                table: "DietsFoods",
                column: "F_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_CategoriesC_Id",
                table: "Exercises",
                column: "CategoriesC_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UsersDiets_D_Id",
                table: "UsersDiets",
                column: "D_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UsersDiets_FoodsF_Id",
                table: "UsersDiets",
                column: "FoodsF_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UsersExercises_E_Id",
                table: "UsersExercises",
                column: "E_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DietsFoods");

            migrationBuilder.DropTable(
                name: "UsersDiets");

            migrationBuilder.DropTable(
                name: "UsersExercises");

            migrationBuilder.DropTable(
                name: "Diets");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
