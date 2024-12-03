﻿// <auto-generated />
using System;
using ExerciseXData_ExerciseLibrary.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExerciseXData_ExerciseLibrary.Migrations
{
    [DbContext(typeof(ExerciseDbContext))]
    partial class ExerciseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExerciseXData_ExerciseLibrary.Models.CategoriesModel", b =>
                {
                    b.Property<int>("C_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("C_Id"));

                    b.Property<byte[]>("C_Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("C_Modified_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("C_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("C_Id");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            C_Id = 1,
                            C_Modified_Date = new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8282),
                            C_Name = "Cardio"
                        },
                        new
                        {
                            C_Id = 2,
                            C_Modified_Date = new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8283),
                            C_Name = "Strength"
                        },
                        new
                        {
                            C_Id = 3,
                            C_Modified_Date = new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8284),
                            C_Name = "Core"
                        },
                        new
                        {
                            C_Id = 4,
                            C_Modified_Date = new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8286),
                            C_Name = "Flexibility & Movement"
                        });
                });

            modelBuilder.Entity("ExerciseXData_ExerciseLibrary.Models.ExercisePlanExercisesModel", b =>
                {
                    b.Property<int>("ExercisePlanEP_Id")
                        .HasColumnType("int");

                    b.Property<int>("ExercisesE_Id")
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("Reps")
                        .HasColumnType("int");

                    b.Property<string>("RestTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sets")
                        .HasColumnType("int");

                    b.HasKey("ExercisePlanEP_Id", "ExercisesE_Id");

                    b.HasIndex("ExercisesE_Id");

                    b.ToTable("ExercisePlanExercises");

                    b.HasData(
                        new
                        {
                            ExercisePlanEP_Id = 1,
                            ExercisesE_Id = 1,
                            Duration = 600,
                            Reps = 0,
                            RestTime = "2 minutes",
                            Sets = 1
                        },
                        new
                        {
                            ExercisePlanEP_Id = 1,
                            ExercisesE_Id = 2,
                            Duration = 600,
                            Reps = 0,
                            RestTime = "2 minutes",
                            Sets = 1
                        },
                        new
                        {
                            ExercisePlanEP_Id = 1,
                            ExercisesE_Id = 3,
                            Duration = 600,
                            Reps = 0,
                            RestTime = "2 minutes",
                            Sets = 1
                        },
                        new
                        {
                            ExercisePlanEP_Id = 2,
                            ExercisesE_Id = 5,
                            Duration = 0,
                            Reps = 12,
                            RestTime = "30 seconds",
                            Sets = 3
                        },
                        new
                        {
                            ExercisePlanEP_Id = 2,
                            ExercisesE_Id = 6,
                            Duration = 0,
                            Reps = 15,
                            RestTime = "30 seconds",
                            Sets = 3
                        },
                        new
                        {
                            ExercisePlanEP_Id = 2,
                            ExercisesE_Id = 7,
                            Duration = 0,
                            Reps = 10,
                            RestTime = "30 seconds",
                            Sets = 3
                        },
                        new
                        {
                            ExercisePlanEP_Id = 2,
                            ExercisesE_Id = 8,
                            Duration = 0,
                            Reps = 8,
                            RestTime = "45 seconds",
                            Sets = 3
                        },
                        new
                        {
                            ExercisePlanEP_Id = 3,
                            ExercisesE_Id = 9,
                            Duration = 60,
                            Reps = 0,
                            RestTime = "30 seconds",
                            Sets = 3
                        },
                        new
                        {
                            ExercisePlanEP_Id = 3,
                            ExercisesE_Id = 10,
                            Duration = 0,
                            Reps = 20,
                            RestTime = "30 seconds",
                            Sets = 3
                        },
                        new
                        {
                            ExercisePlanEP_Id = 3,
                            ExercisesE_Id = 11,
                            Duration = 0,
                            Reps = 15,
                            RestTime = "30 seconds",
                            Sets = 3
                        },
                        new
                        {
                            ExercisePlanEP_Id = 3,
                            ExercisesE_Id = 12,
                            Duration = 0,
                            Reps = 20,
                            RestTime = "30 seconds",
                            Sets = 3
                        },
                        new
                        {
                            ExercisePlanEP_Id = 4,
                            ExercisesE_Id = 13,
                            Duration = 30,
                            Reps = 0,
                            RestTime = "15 seconds",
                            Sets = 1
                        },
                        new
                        {
                            ExercisePlanEP_Id = 4,
                            ExercisesE_Id = 14,
                            Duration = 30,
                            Reps = 0,
                            RestTime = "15 seconds",
                            Sets = 1
                        },
                        new
                        {
                            ExercisePlanEP_Id = 4,
                            ExercisesE_Id = 15,
                            Duration = 30,
                            Reps = 0,
                            RestTime = "15 seconds",
                            Sets = 1
                        },
                        new
                        {
                            ExercisePlanEP_Id = 4,
                            ExercisesE_Id = 16,
                            Duration = 30,
                            Reps = 0,
                            RestTime = "15 seconds",
                            Sets = 1
                        });
                });

            modelBuilder.Entity("ExerciseXData_ExerciseLibrary.Models.ExercisePlansModel", b =>
                {
                    b.Property<int>("EP_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EP_Id"));

                    b.Property<DateTime>("EP_CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EP_Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EP_Difficulty")
                        .HasColumnType("int");

                    b.Property<string>("EP_Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("EP_Id");

                    b.ToTable("ExercisePlans");

                    b.HasData(
                        new
                        {
                            EP_Id = 1,
                            EP_CreatedDate = new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8504),
                            EP_Description = "Exercises that taregets the upper body.",
                            EP_Difficulty = 1,
                            EP_Name = "Upper Body focus"
                        },
                        new
                        {
                            EP_Id = 2,
                            EP_CreatedDate = new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8506),
                            EP_Description = "Exercises that taregets the lower body.",
                            EP_Difficulty = 2,
                            EP_Name = "Lower Body focus"
                        },
                        new
                        {
                            EP_Id = 3,
                            EP_CreatedDate = new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8507),
                            EP_Description = "Exercises that taregets the full body.",
                            EP_Difficulty = 3,
                            EP_Name = "Full Body focus"
                        },
                        new
                        {
                            EP_Id = 4,
                            EP_CreatedDate = new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8509),
                            EP_Description = "Exercises that target flexibility.",
                            EP_Difficulty = 1,
                            EP_Name = "Flexibility focus"
                        });
                });

            modelBuilder.Entity("ExerciseXData_ExerciseLibrary.Models.ExercisesModel", b =>
                {
                    b.Property<int>("E_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("E_Id"));

                    b.Property<int>("CategoriesC_Id")
                        .HasColumnType("int");

                    b.Property<string>("E_Cons_1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("E_Cons_2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("E_Cons_3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("E_Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("E_Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("E_Modified_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("E_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("E_Pros_1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("E_Pros_2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("E_Pros_3")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("E_Id");

                    b.HasIndex("CategoriesC_Id");

                    b.ToTable("Exercises");

                    b.HasData(
                        new
                        {
                            E_Id = 1,
                            CategoriesC_Id = 1,
                            E_Cons_1 = "May cause injury to knees",
                            E_Description = "Step one leg forward into a deep lunge, with your back leg extended behind you.\r\n Keep your back straight and push your hips forward to feel a stretch in your hip flexors and thighs.",
                            E_Modified_Date = new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8407),
                            E_Name = "Running",
                            E_Pros_1 = "Improves flexibility"
                        },
                        new
                        {
                            E_Id = 2,
                            CategoriesC_Id = 1,
                            E_Cons_1 = "Requires access to a bike or cycling equipment",
                            E_Description = " A low - impact cardio exercise that strengthens the lower body and improves endurance.",
                            E_Modified_Date = new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8408),
                            E_Name = "Cycling",
                            E_Pros_1 = "Enhances cardiovascular health."
                        },
                        new
                        {
                            E_Id = 3,
                            CategoriesC_Id = 1,
                            E_Cons_1 = " Requires access to a pool.",
                            E_Description = "A full-body workout that improves cardiovascular health and builds strength.",
                            E_Modified_Date = new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8410),
                            E_Name = "Swimming",
                            E_Pros_1 = "Low impact, ideal for joint health."
                        },
                        new
                        {
                            E_Id = 4,
                            CategoriesC_Id = 1,
                            E_Cons_1 = "Less effective for building muscle compared to other exercises",
                            E_Description = "A simple and effective way to improve overall fitness and maintain a healthy weight.",
                            E_Modified_Date = new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8412),
                            E_Name = "Walking",
                            E_Pros_1 = "Easy to start, no equipment needed"
                        },
                        new
                        {
                            E_Id = 5,
                            CategoriesC_Id = 2,
                            E_Cons_1 = "Can strain wrists if not performed correctly",
                            E_Description = "A bodyweight exercise targeting the chest, shoulders, and triceps.\r\nPerform a plank position and lower your body to the ground, then push back up\r\nWide push-ups or diamond push-ups for targeting different muscles.",
                            E_Modified_Date = new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8413),
                            E_Name = "Push-ups",
                            E_Pros_1 = "Builds upper body strength without equipment"
                        },
                        new
                        {
                            E_Id = 6,
                            CategoriesC_Id = 2,
                            E_Cons_1 = "May cause elbow pain if done incorrectly",
                            E_Description = "A beginner-friendly exercise to build strength in the chest, shoulders, and triceps.\r\nHow: Stand facing a wall, place your hands shoulder-width apart on the wall, and perform push-ups by bending your elbows and leaning toward the wall, then pushing back to the starting position.\r\nVariation: Adjust the angle by stepping closer or farther from the wall to make it easier or harder.",
                            E_Modified_Date = new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8415),
                            E_Name = "Wall Push-ups",
                            E_Pros_1 = "Builds arm strength"
                        },
                        new
                        {
                            E_Id = 7,
                            CategoriesC_Id = 2,
                            E_Cons_1 = "Can cause joint strain if form is improper",
                            E_Description = "Builds core stability and strengthens shoulders and chest.\r\nHow: Start in a plank position and tap one shoulder at a time with the opposite hand while maintaining balance.",
                            E_Modified_Date = new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8417),
                            E_Name = "Plank-to-Shoulder Taps",
                            E_Pros_1 = "Great for strengthening upper body, legs and glutes"
                        },
                        new
                        {
                            E_Id = 8,
                            CategoriesC_Id = 2,
                            E_Cons_1 = "Can strain wrists if not performed correctly",
                            E_Description = "Focuses on the triceps, chest, and shoulders.\r\nHow: Use a sturdy surface like a chair or perform parallel bar dips to push yourself up and down.",
                            E_Modified_Date = new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8418),
                            E_Name = "Dips",
                            E_Pros_1 = "Builds upper body strength without equipment"
                        },
                        new
                        {
                            E_Id = 9,
                            CategoriesC_Id = 3,
                            E_Cons_1 = "Can be challenging for beginners to hold for long periods",
                            E_Description = "A core-strengthening exercise that improves posture and stability.",
                            E_Modified_Date = new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8420),
                            E_Name = "Planks",
                            E_Pros_1 = "Enhances core strength and stability"
                        },
                        new
                        {
                            E_Id = 10,
                            CategoriesC_Id = 3,
                            E_Cons_1 = "Can strain the neck if performed improperly",
                            E_Description = "A classic core exercise targeting the abdominal muscles.",
                            E_Modified_Date = new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8422),
                            E_Name = "Crunches",
                            E_Pros_1 = "Focuses on abdominal muscle strength"
                        },
                        new
                        {
                            E_Id = 11,
                            CategoriesC_Id = 3,
                            E_Cons_1 = "May cause lower back strain if the core is weak",
                            E_Description = "An abdominal exercise focusing on the lower abs and hip flexors.",
                            E_Modified_Date = new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8423),
                            E_Name = "Leg Raises",
                            E_Pros_1 = "Strengthens core and improves hip mobility"
                        },
                        new
                        {
                            E_Id = 12,
                            CategoriesC_Id = 3,
                            E_Cons_1 = "Requires good wrist and shoulder stability",
                            E_Description = "A high-intensity exercise that combines cardio and strength training.",
                            E_Modified_Date = new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8425),
                            E_Name = "Mountain Climbers",
                            E_Pros_1 = "Boosts heart rate and burns calories quickly"
                        },
                        new
                        {
                            E_Id = 13,
                            CategoriesC_Id = 4,
                            E_Cons_1 = "Provides no cardio or strength benefits",
                            E_Description = "A flexibility exercise that stretches the hamstring muscles.",
                            E_Modified_Date = new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8427),
                            E_Name = "Hamstring Stretch",
                            E_Pros_1 = "Improves flexibility and reduces injury risk"
                        },
                        new
                        {
                            E_Id = 14,
                            CategoriesC_Id = 4,
                            E_Cons_1 = "Does not build muscle or burn calories",
                            E_Description = "A simple stretch to improve shoulder mobility and reduce tension.",
                            E_Modified_Date = new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8428),
                            E_Name = "Shoulder Stretch",
                            E_Pros_1 = "Alleviates tension and improves flexibility"
                        },
                        new
                        {
                            E_Id = 15,
                            CategoriesC_Id = 4,
                            E_Cons_1 = "Limited to improving neck flexibility only",
                            E_Description = "A gentle stretch to reduce tension and stiffness in the neck.",
                            E_Modified_Date = new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8430),
                            E_Name = "Neck Stretch",
                            E_Pros_1 = "Relieves neck stiffness and improves mobility"
                        },
                        new
                        {
                            E_Id = 16,
                            CategoriesC_Id = 4,
                            E_Cons_1 = "May cause injury to knees",
                            E_Description = "Sit or stand with your back straight. Slowly tilt your head towards your right shoulder, bringing your ear closer to it.\r\nHold for 15-20 seconds and then switch to the other side.",
                            E_Modified_Date = new DateTime(2024, 12, 3, 8, 47, 43, 680, DateTimeKind.Local).AddTicks(8432),
                            E_Name = "Lunge Stretch",
                            E_Pros_1 = "Improves flexibility"
                        });
                });

            modelBuilder.Entity("ExerciseXData_ExerciseLibrary.Models.ExercisePlanExercisesModel", b =>
                {
                    b.HasOne("ExerciseXData_ExerciseLibrary.Models.ExercisePlansModel", "ExercisePlan")
                        .WithMany("ExercisePlanExercises")
                        .HasForeignKey("ExercisePlanEP_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExerciseXData_ExerciseLibrary.Models.ExercisesModel", "Exercises")
                        .WithMany("ExercisePlanExercises")
                        .HasForeignKey("ExercisesE_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ExercisePlan");

                    b.Navigation("Exercises");
                });

            modelBuilder.Entity("ExerciseXData_ExerciseLibrary.Models.ExercisesModel", b =>
                {
                    b.HasOne("ExerciseXData_ExerciseLibrary.Models.CategoriesModel", "Categories")
                        .WithMany("Exercises")
                        .HasForeignKey("CategoriesC_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("ExerciseXData_ExerciseLibrary.Models.CategoriesModel", b =>
                {
                    b.Navigation("Exercises");
                });

            modelBuilder.Entity("ExerciseXData_ExerciseLibrary.Models.ExercisePlansModel", b =>
                {
                    b.Navigation("ExercisePlanExercises");
                });

            modelBuilder.Entity("ExerciseXData_ExerciseLibrary.Models.ExercisesModel", b =>
                {
                    b.Navigation("ExercisePlanExercises");
                });
#pragma warning restore 612, 618
        }
    }
}
