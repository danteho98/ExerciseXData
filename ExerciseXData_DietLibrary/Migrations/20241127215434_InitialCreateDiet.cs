using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExerciseXData_DietLibrary.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateDiet : Migration
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
                name: "DietsFoodsModel",
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
                    table.PrimaryKey("PK_DietsFoodsModel", x => new { x.DietsD_Id, x.FoodsF_Id });
                    table.ForeignKey(
                        name: "FK_DietsFoodsModel_Diets_DietsD_Id",
                        column: x => x.DietsD_Id,
                        principalTable: "Diets",
                        principalColumn: "D_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DietsFoodsModel_Foods_FoodsF_Id",
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
                    U_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    D_Id = table.Column<int>(type: "int", nullable: false),
                    Custom_Diet_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UD_Serving_Size = table.Column<int>(type: "int", nullable: true),
                    UD_Frequency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UD_Total_Calaroies = table.Column<int>(type: "int", nullable: true),
                    UD_Modified_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FoodsModelF_Id = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DietId = table.Column<int>(type: "int", nullable: false),
                    DietName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DietDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                        name: "FK_UsersDiets_Foods_FoodsModelF_Id",
                        column: x => x.FoodsModelF_Id,
                        principalTable: "Foods",
                        principalColumn: "F_Id");
                    table.ForeignKey(
                        name: "FK_UsersDiets_UsersModel_U_Id",
                        column: x => x.U_Id,
                        principalTable: "UsersModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Diets",
                columns: new[] { "D_Id", "D_Cons_1", "D_Cons_2", "D_Cons_3", "D_Description", "D_Modified_Date", "D_Name", "D_Pros_1", "D_Pros_2", "D_Pros_3" },
                values: new object[,]
                {
                    { 1, null, null, null, null, new DateTime(2024, 11, 28, 5, 54, 34, 163, DateTimeKind.Local).AddTicks(9378), "Keto Diet", null, null, null },
                    { 2, null, null, null, null, new DateTime(2024, 11, 28, 5, 54, 34, 163, DateTimeKind.Local).AddTicks(9388), "Mediterranean Diet", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "F_Id", "F_Calories", "F_Group", "F_Image", "F_Modified_Date", "F_Name" },
                values: new object[,]
                {
                    { 1, 160, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avocado" },
                    { 2, 208, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Salmon" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DietsFoodsModel_FoodsF_Id",
                table: "DietsFoodsModel",
                column: "FoodsF_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UsersDiets_D_Id",
                table: "UsersDiets",
                column: "D_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UsersDiets_FoodsModelF_Id",
                table: "UsersDiets",
                column: "FoodsModelF_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UsersDiets_U_Id",
                table: "UsersDiets",
                column: "U_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DietsFoodsModel");

            migrationBuilder.DropTable(
                name: "UsersDiets");

            migrationBuilder.DropTable(
                name: "Diets");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "UsersModel");
        }
    }
}
