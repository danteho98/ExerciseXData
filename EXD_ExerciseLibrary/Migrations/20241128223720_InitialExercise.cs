using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExerciseXData_ExerciseLibrary.Migrations
{
    /// <inheritdoc />
    public partial class InitialExercise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriesModel",
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
                    table.PrimaryKey("PK_CategoriesModel", x => x.C_Id);
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
                name: "Exercises",
                columns: table => new
                {
                    E_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    C_Id = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_Exercises_CategoriesModel_CategoriesC_Id",
                        column: x => x.CategoriesC_Id,
                        principalTable: "CategoriesModel",
                        principalColumn: "C_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersExercises",
                columns: table => new
                {
                    UE_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    U_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    E_Id = table.Column<int>(type: "int", nullable: false),
                    Repetition = table.Column<int>(type: "int", nullable: false),
                    Sets = table.Column<int>(type: "int", nullable: false),
                    Duration_sec = table.Column<int>(type: "int", nullable: false),
                    UE_Modified_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersExercises", x => x.UE_Id);
                    table.ForeignKey(
                        name: "FK_UsersExercises_Exercises_E_Id",
                        column: x => x.E_Id,
                        principalTable: "Exercises",
                        principalColumn: "E_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersExercises_UsersModel_U_Id",
                        column: x => x.U_Id,
                        principalTable: "UsersModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_CategoriesC_Id",
                table: "Exercises",
                column: "CategoriesC_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UsersExercises_E_Id",
                table: "UsersExercises",
                column: "E_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UsersExercises_U_Id",
                table: "UsersExercises",
                column: "U_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersExercises");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "UsersModel");

            migrationBuilder.DropTable(
                name: "CategoriesModel");
        }
    }
}
