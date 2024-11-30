using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExerciseXData_ExerciseLibrary.Migrations
{
    /// <inheritdoc />
    public partial class TemporaryRemoveUserExercise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersExercises");

            migrationBuilder.DropTable(
                name: "UsersModel");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "C_Id",
                keyValue: 1,
                column: "C_Modified_Date",
                value: new DateTime(2024, 11, 30, 11, 43, 21, 924, DateTimeKind.Local).AddTicks(4353));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "C_Id",
                keyValue: 2,
                column: "C_Modified_Date",
                value: new DateTime(2024, 11, 30, 11, 43, 21, 924, DateTimeKind.Local).AddTicks(4355));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "E_Id",
                keyValue: 1,
                column: "E_Modified_Date",
                value: new DateTime(2024, 11, 30, 11, 43, 21, 924, DateTimeKind.Local).AddTicks(4457));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "E_Id",
                keyValue: 2,
                column: "E_Modified_Date",
                value: new DateTime(2024, 11, 30, 11, 43, 21, 924, DateTimeKind.Local).AddTicks(4459));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    U_Age = table.Column<int>(type: "int", nullable: false),
                    U_Created_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    U_Goal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    U_Height_CM = table.Column<double>(type: "float", nullable: false),
                    U_Last_Login = table.Column<DateTime>(type: "datetime2", nullable: false),
                    U_Lifestyle_Condition_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    U_Lifestyle_Condition_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    U_Lifestyle_Condition_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    U_Lifestyle_Condition_4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    U_Lifestyle_Condition_5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    U_UserGender = table.Column<int>(type: "int", nullable: false),
                    U_Weight_KG = table.Column<double>(type: "float", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersExercises",
                columns: table => new
                {
                    UE_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    E_Id = table.Column<int>(type: "int", nullable: false),
                    U_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Duration_sec = table.Column<int>(type: "int", nullable: false),
                    Repetition = table.Column<int>(type: "int", nullable: false),
                    Sets = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_UsersExercises_E_Id",
                table: "UsersExercises",
                column: "E_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UsersExercises_U_Id",
                table: "UsersExercises",
                column: "U_Id");
        }
    }
}
