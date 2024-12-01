using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExerciseXData_SharedLibrary.Migrations
{
    /// <inheritdoc />
    public partial class NewShared : Migration
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
                name: "DietsModel",
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
                    table.PrimaryKey("PK_DietsModel", x => x.D_Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodsModel",
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
                    table.PrimaryKey("PK_FoodsModel", x => x.F_Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    U_UserGender = table.Column<int>(type: "int", nullable: false),
                    U_Age = table.Column<int>(type: "int", nullable: false),
                    U_Height_CM = table.Column<double>(type: "float", nullable: false),
                    U_Weight_KG = table.Column<double>(type: "float", nullable: false),
                    U_Goal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    U_Lifestyle_Condition_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    U_Lifestyle_Condition_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    U_Lifestyle_Condition_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    U_Lifestyle_Condition_4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    U_Lifestyle_Condition_5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    U_Created_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    U_Last_Login = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                name: "ExercisesModel",
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
                    table.PrimaryKey("PK_ExercisesModel", x => x.E_Id);
                    table.ForeignKey(
                        name: "FK_ExercisesModel_Categories_CategoriesC_Id",
                        column: x => x.CategoriesC_Id,
                        principalTable: "Categories",
                        principalColumn: "C_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DietsFoodsModel",
                columns: table => new
                {
                    DF_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DietsD_Id = table.Column<int>(type: "int", nullable: false),
                    FoodsF_Id = table.Column<int>(type: "int", nullable: false),
                    DF_Serving_Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DF_Recommended_Servings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DF_Frequency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DF_Total_Calories = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DF_Modified_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietsFoodsModel", x => x.DF_Id);
                    table.ForeignKey(
                        name: "FK_DietsFoodsModel_DietsModel_DietsD_Id",
                        column: x => x.DietsD_Id,
                        principalTable: "DietsModel",
                        principalColumn: "D_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DietsFoodsModel_FoodsModel_FoodsF_Id",
                        column: x => x.FoodsF_Id,
                        principalTable: "FoodsModel",
                        principalColumn: "F_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersDiets",
                columns: table => new
                {
                    U_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    D_Id = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DietsD_Id = table.Column<int>(type: "int", nullable: false),
                    Custom_Diet_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UD_Serving_Size = table.Column<int>(type: "int", nullable: true),
                    UD_Frequency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UD_Total_Calaroies = table.Column<int>(type: "int", nullable: true),
                    UD_Modified_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersDiets", x => new { x.U_Id, x.D_Id });
                    table.ForeignKey(
                        name: "FK_UsersDiets_DietsModel_DietsD_Id",
                        column: x => x.DietsD_Id,
                        principalTable: "DietsModel",
                        principalColumn: "D_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersDiets_UsersModel_UsersId",
                        column: x => x.UsersId,
                        principalTable: "UsersModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UsersExercises",
                columns: table => new
                {
                    UE_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    U_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    E_Id = table.Column<int>(type: "int", nullable: false),
                    Repetition = table.Column<int>(type: "int", nullable: false),
                    Sets = table.Column<int>(type: "int", nullable: false),
                    Duration_sec = table.Column<int>(type: "int", nullable: false),
                    UE_Modified_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ExercisesE_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersExercises", x => x.UE_Id);
                    table.ForeignKey(
                        name: "FK_UsersExercises_ExercisesModel_ExercisesE_Id",
                        column: x => x.ExercisesE_Id,
                        principalTable: "ExercisesModel",
                        principalColumn: "E_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersExercises_UsersModel_UsersId",
                        column: x => x.UsersId,
                        principalTable: "UsersModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DietsFoodsModel_DietsD_Id",
                table: "DietsFoodsModel",
                column: "DietsD_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DietsFoodsModel_FoodsF_Id",
                table: "DietsFoodsModel",
                column: "FoodsF_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ExercisesModel_CategoriesC_Id",
                table: "ExercisesModel",
                column: "CategoriesC_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UsersDiets_DietsD_Id",
                table: "UsersDiets",
                column: "DietsD_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UsersDiets_UsersId",
                table: "UsersDiets",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersExercises_ExercisesE_Id",
                table: "UsersExercises",
                column: "ExercisesE_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UsersExercises_UsersId",
                table: "UsersExercises",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DietsFoodsModel");

            migrationBuilder.DropTable(
                name: "UsersDiets");

            migrationBuilder.DropTable(
                name: "UsersExercises");

            migrationBuilder.DropTable(
                name: "FoodsModel");

            migrationBuilder.DropTable(
                name: "DietsModel");

            migrationBuilder.DropTable(
                name: "ExercisesModel");

            migrationBuilder.DropTable(
                name: "UsersModel");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
