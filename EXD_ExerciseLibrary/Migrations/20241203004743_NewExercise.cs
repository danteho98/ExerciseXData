using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExerciseXData_ExerciseLibrary.Migrations
{
    /// <inheritdoc />
    public partial class NewExercise : Migration
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
                name: "ExercisePlans",
                columns: table => new
                {
                    EP_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EP_Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EP_Difficulty = table.Column<int>(type: "int", nullable: false),
                    EP_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EP_CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExercisePlans", x => x.EP_Id);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
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
                    table.PrimaryKey("PK_Exercises", x => x.E_Id);
                    table.ForeignKey(
                        name: "FK_Exercises_Categories_CategoriesC_Id",
                        column: x => x.CategoriesC_Id,
                        principalTable: "Categories",
                        principalColumn: "C_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExercisePlanExercises",
                columns: table => new
                {
                    ExercisePlanEP_Id = table.Column<int>(type: "int", nullable: false),
                    ExercisesE_Id = table.Column<int>(type: "int", nullable: false),
                    Sets = table.Column<int>(type: "int", nullable: false),
                    Reps = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    RestTime = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExercisePlanExercises", x => new { x.ExercisePlanEP_Id, x.ExercisesE_Id });
                    table.ForeignKey(
                        name: "FK_ExercisePlanExercises_ExercisePlans_ExercisePlanEP_Id",
                        column: x => x.ExercisePlanEP_Id,
                        principalTable: "ExercisePlans",
                        principalColumn: "EP_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExercisePlanExercises_Exercises_ExercisesE_Id",
                        column: x => x.ExercisesE_Id,
                        principalTable: "Exercises",
                        principalColumn: "E_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "C_Id", "C_Image", "C_Modified_Date", "C_Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8282), "Cardio" },
                    { 2, null, new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8283), "Strength" },
                    { 3, null, new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8284), "Core" },
                    { 4, null, new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8286), "Flexibility & Movement" }
                });

            migrationBuilder.InsertData(
                table: "ExercisePlans",
                columns: new[] { "EP_Id", "EP_CreatedDate", "EP_Description", "EP_Difficulty", "EP_Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8504), "Exercises that taregets the upper body.", 1, "Upper Body focus" },
                    { 2, new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8506), "Exercises that taregets the lower body.", 2, "Lower Body focus" },
                    { 3, new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8507), "Exercises that taregets the full body.", 3, "Full Body focus" },
                    { 4, new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8509), "Exercises that target flexibility.", 1, "Flexibility focus" }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "E_Id", "CategoriesC_Id", "E_Cons_1", "E_Cons_2", "E_Cons_3", "E_Description", "E_Image", "E_Modified_Date", "E_Name", "E_Pros_1", "E_Pros_2", "E_Pros_3" },
                values: new object[,]
                {
                    { 1, 1, "May cause injury to knees", null, null, "Step one leg forward into a deep lunge, with your back leg extended behind you.\r\n Keep your back straight and push your hips forward to feel a stretch in your hip flexors and thighs.", null, new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8407), "Running", "Improves flexibility", null, null },
                    { 2, 1, "Requires access to a bike or cycling equipment", null, null, " A low - impact cardio exercise that strengthens the lower body and improves endurance.", null, new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8408), "Cycling", "Enhances cardiovascular health.", null, null },
                    { 3, 1, " Requires access to a pool.", null, null, "A full-body workout that improves cardiovascular health and builds strength.", null, new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8410), "Swimming", "Low impact, ideal for joint health.", null, null },
                    { 4, 1, "Less effective for building muscle compared to other exercises", null, null, "A simple and effective way to improve overall fitness and maintain a healthy weight.", null, new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8412), "Walking", "Easy to start, no equipment needed", null, null },
                    { 5, 2, "Can strain wrists if not performed correctly", null, null, "A bodyweight exercise targeting the chest, shoulders, and triceps.\r\nPerform a plank position and lower your body to the ground, then push back up\r\nWide push-ups or diamond push-ups for targeting different muscles.", null, new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8413), "Push-ups", "Builds upper body strength without equipment", null, null },
                    { 6, 2, "May cause elbow pain if done incorrectly", null, null, "A beginner-friendly exercise to build strength in the chest, shoulders, and triceps.\r\nHow: Stand facing a wall, place your hands shoulder-width apart on the wall, and perform push-ups by bending your elbows and leaning toward the wall, then pushing back to the starting position.\r\nVariation: Adjust the angle by stepping closer or farther from the wall to make it easier or harder.", null, new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8415), "Wall Push-ups", "Builds arm strength", null, null },
                    { 7, 2, "Can cause joint strain if form is improper", null, null, "Builds core stability and strengthens shoulders and chest.\r\nHow: Start in a plank position and tap one shoulder at a time with the opposite hand while maintaining balance.", null, new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8417), "Plank-to-Shoulder Taps", "Great for strengthening upper body, legs and glutes", null, null },
                    { 8, 2, "Can strain wrists if not performed correctly", null, null, "Focuses on the triceps, chest, and shoulders.\r\nHow: Use a sturdy surface like a chair or perform parallel bar dips to push yourself up and down.", null, new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8418), "Dips", "Builds upper body strength without equipment", null, null },
                    { 9, 3, "Can be challenging for beginners to hold for long periods", null, null, "A core-strengthening exercise that improves posture and stability.", null, new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8420), "Planks", "Enhances core strength and stability", null, null },
                    { 10, 3, "Can strain the neck if performed improperly", null, null, "A classic core exercise targeting the abdominal muscles.", null, new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8422), "Crunches", "Focuses on abdominal muscle strength", null, null },
                    { 11, 3, "May cause lower back strain if the core is weak", null, null, "An abdominal exercise focusing on the lower abs and hip flexors.", null, new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8423), "Leg Raises", "Strengthens core and improves hip mobility", null, null },
                    { 12, 3, "Requires good wrist and shoulder stability", null, null, "A high-intensity exercise that combines cardio and strength training.", null, new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8425), "Mountain Climbers", "Boosts heart rate and burns calories quickly", null, null },
                    { 13, 4, "Provides no cardio or strength benefits", null, null, "A flexibility exercise that stretches the hamstring muscles.", null, new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8427), "Hamstring Stretch", "Improves flexibility and reduces injury risk", null, null },
                    { 14, 4, "Does not build muscle or burn calories", null, null, "A simple stretch to improve shoulder mobility and reduce tension.", null, new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8428), "Shoulder Stretch", "Alleviates tension and improves flexibility", null, null },
                    { 15, 4, "Limited to improving neck flexibility only", null, null, "A gentle stretch to reduce tension and stiffness in the neck.", null, new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8430), "Neck Stretch", "Relieves neck stiffness and improves mobility", null, null },
                    { 16, 4, "May cause injury to knees", null, null, "Sit or stand with your back straight. Slowly tilt your head towards your right shoulder, bringing your ear closer to it.\r\nHold for 15-20 seconds and then switch to the other side.", null, new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8432), "Lunge Stretch", "Improves flexibility", null, null }
                });

            migrationBuilder.InsertData(
                table: "ExercisePlanExercises",
                columns: new[] { "ExercisePlanEP_Id", "ExercisesE_Id", "Duration", "Reps", "RestTime", "Sets" },
                values: new object[,]
                {
                    { 1, 1, 600, 0, "2 minutes", 1 },
                    { 1, 2, 600, 0, "2 minutes", 1 },
                    { 1, 3, 600, 0, "2 minutes", 1 },
                    { 2, 5, 0, 12, "30 seconds", 3 },
                    { 2, 6, 0, 15, "30 seconds", 3 },
                    { 2, 7, 0, 10, "30 seconds", 3 },
                    { 2, 8, 0, 8, "45 seconds", 3 },
                    { 3, 9, 60, 0, "30 seconds", 3 },
                    { 3, 10, 0, 20, "30 seconds", 3 },
                    { 3, 11, 0, 15, "30 seconds", 3 },
                    { 3, 12, 0, 20, "30 seconds", 3 },
                    { 4, 13, 30, 0, "15 seconds", 1 },
                    { 4, 14, 30, 0, "15 seconds", 1 },
                    { 4, 15, 30, 0, "15 seconds", 1 },
                    { 4, 16, 30, 0, "15 seconds", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExercisePlanExercises_ExercisesE_Id",
                table: "ExercisePlanExercises",
                column: "ExercisesE_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_CategoriesC_Id",
                table: "Exercises",
                column: "CategoriesC_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExercisePlanExercises");

            migrationBuilder.DropTable(
                name: "ExercisePlans");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
