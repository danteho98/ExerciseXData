﻿// <auto-generated />
using System;
using ExerciseXData_DietLibrary.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExerciseXData_DietLibrary.Migrations
{
    [DbContext(typeof(DietDbContext))]
    partial class DietDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExerciseXData_DietLibrary.Models.DietsFoodsModel", b =>
                {
                    b.Property<int>("DietsD_Id")
                        .HasColumnType("int");

                    b.Property<int?>("FoodsF_Id")
                        .HasColumnType("int");

                    b.Property<string>("DF_Frequency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DF_Modified_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("DF_Recommended_Servings")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DF_Serving_Size")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DF_Total_Calories")
                        .HasColumnType("int");

                    b.HasKey("DietsD_Id", "FoodsF_Id");

                    b.HasIndex("FoodsF_Id");

                    b.ToTable("DietsFoods");

                    b.HasData(
                        new
                        {
                            DietsD_Id = 1,
                            FoodsF_Id = 1,
                            DF_Frequency = "Daily",
                            DF_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3812),
                            DF_Recommended_Servings = "2-3 servings/day",
                            DF_Serving_Size = "1 tablespoon",
                            DF_Total_Calories = 119
                        },
                        new
                        {
                            DietsD_Id = 1,
                            FoodsF_Id = 2,
                            DF_Frequency = "Weekly",
                            DF_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3814),
                            DF_Recommended_Servings = "2-3 servings/week",
                            DF_Serving_Size = "4 oz",
                            DF_Total_Calories = 232
                        },
                        new
                        {
                            DietsD_Id = 1,
                            FoodsF_Id = 3,
                            DF_Frequency = "Daily",
                            DF_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3816),
                            DF_Recommended_Servings = "1-2 servings/day",
                            DF_Serving_Size = "1 cup",
                            DF_Total_Calories = 222
                        },
                        new
                        {
                            DietsD_Id = 1,
                            FoodsF_Id = 4,
                            DF_Frequency = "Daily",
                            DF_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3818),
                            DF_Recommended_Servings = "1-2 servings/day",
                            DF_Serving_Size = "1 cup cooked",
                            DF_Total_Calories = 41
                        },
                        new
                        {
                            DietsD_Id = 1,
                            FoodsF_Id = 5,
                            DF_Frequency = "Daily",
                            DF_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3819),
                            DF_Recommended_Servings = "1-2 servings/day",
                            DF_Serving_Size = "1 cup",
                            DF_Total_Calories = 60
                        },
                        new
                        {
                            DietsD_Id = 1,
                            FoodsF_Id = 6,
                            DF_Frequency = "Weekly",
                            DF_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3821),
                            DF_Recommended_Servings = "3-4 servings/week",
                            DF_Serving_Size = "1/2 cup cooked",
                            DF_Total_Calories = 134
                        },
                        new
                        {
                            DietsD_Id = 1,
                            FoodsF_Id = 7,
                            DF_Frequency = "Daily",
                            DF_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3823),
                            DF_Recommended_Servings = "1-2 servings/day",
                            DF_Serving_Size = "1 ounce",
                            DF_Total_Calories = 160
                        },
                        new
                        {
                            DietsD_Id = 1,
                            FoodsF_Id = 8,
                            DF_Frequency = "Daily",
                            DF_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3825),
                            DF_Recommended_Servings = "1-2 servings/day",
                            DF_Serving_Size = "1 teaspoon dried",
                            DF_Total_Calories = 3
                        },
                        new
                        {
                            DietsD_Id = 1,
                            FoodsF_Id = 9,
                            DF_Frequency = "Daily",
                            DF_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3827),
                            DF_Recommended_Servings = "1-2 servings/day",
                            DF_Serving_Size = "1/2 cup",
                            DF_Total_Calories = 100
                        },
                        new
                        {
                            DietsD_Id = 1,
                            FoodsF_Id = 10,
                            DF_Frequency = "Daily",
                            DF_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3829),
                            DF_Recommended_Servings = "1 serving/day",
                            DF_Serving_Size = "5 oz",
                            DF_Total_Calories = 125
                        },
                        new
                        {
                            DietsD_Id = 2,
                            FoodsF_Id = 1,
                            DF_Frequency = "Daily",
                            DF_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3830),
                            DF_Recommended_Servings = "1 serving/day",
                            DF_Serving_Size = "1/2 avocado",
                            DF_Total_Calories = 160
                        },
                        new
                        {
                            DietsD_Id = 2,
                            FoodsF_Id = 2,
                            DF_Frequency = "Daily",
                            DF_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3832),
                            DF_Recommended_Servings = "3-4 servings/day",
                            DF_Serving_Size = "1 large egg",
                            DF_Total_Calories = 72
                        },
                        new
                        {
                            DietsD_Id = 2,
                            FoodsF_Id = 3,
                            DF_Frequency = "Daily",
                            DF_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3834),
                            DF_Recommended_Servings = "1-2 servings/day",
                            DF_Serving_Size = "4 oz",
                            DF_Total_Calories = 187
                        },
                        new
                        {
                            DietsD_Id = 2,
                            FoodsF_Id = 4,
                            DF_Frequency = "Daily",
                            DF_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3836),
                            DF_Recommended_Servings = "1-2 servings/day",
                            DF_Serving_Size = "2 slices",
                            DF_Total_Calories = 80
                        },
                        new
                        {
                            DietsD_Id = 2,
                            FoodsF_Id = 5,
                            DF_Frequency = "Daily",
                            DF_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3838),
                            DF_Recommended_Servings = "2-3 servings/day",
                            DF_Serving_Size = "1 oz",
                            DF_Total_Calories = 115
                        },
                        new
                        {
                            DietsD_Id = 2,
                            FoodsF_Id = 6,
                            DF_Frequency = "Daily",
                            DF_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3839),
                            DF_Recommended_Servings = "2-3 servings/day",
                            DF_Serving_Size = "1 tablespoon",
                            DF_Total_Calories = 119
                        },
                        new
                        {
                            DietsD_Id = 2,
                            FoodsF_Id = 7,
                            DF_Frequency = "Daily",
                            DF_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3841),
                            DF_Recommended_Servings = "1 serving/day",
                            DF_Serving_Size = "1 ounce",
                            DF_Total_Calories = 160
                        },
                        new
                        {
                            DietsD_Id = 2,
                            FoodsF_Id = 8,
                            DF_Frequency = "Weekly",
                            DF_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3843),
                            DF_Recommended_Servings = "2-3 servings/week",
                            DF_Serving_Size = "4 oz",
                            DF_Total_Calories = 232
                        },
                        new
                        {
                            DietsD_Id = 2,
                            FoodsF_Id = 9,
                            DF_Frequency = "Daily",
                            DF_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3845),
                            DF_Recommended_Servings = "2-3 servings/day",
                            DF_Serving_Size = "1 cup",
                            DF_Total_Calories = 25
                        },
                        new
                        {
                            DietsD_Id = 2,
                            FoodsF_Id = 10,
                            DF_Frequency = "Daily",
                            DF_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3847),
                            DF_Recommended_Servings = "1-2 servings/day",
                            DF_Serving_Size = "1 medium zucchini",
                            DF_Total_Calories = 33
                        },
                        new
                        {
                            DietsD_Id = 2,
                            FoodsF_Id = 11,
                            DF_Frequency = "Daily",
                            DF_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3848),
                            DF_Recommended_Servings = "1-2 servings/day",
                            DF_Serving_Size = "1 cup cooked",
                            DF_Total_Calories = 41
                        },
                        new
                        {
                            DietsD_Id = 2,
                            FoodsF_Id = 12,
                            DF_Frequency = "Daily",
                            DF_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3850),
                            DF_Recommended_Servings = "1-2 servings/day",
                            DF_Serving_Size = "1 tablespoon",
                            DF_Total_Calories = 117
                        },
                        new
                        {
                            DietsD_Id = 2,
                            FoodsF_Id = 13,
                            DF_Frequency = "Daily",
                            DF_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3852),
                            DF_Recommended_Servings = "1 serving/day",
                            DF_Serving_Size = "1 oz",
                            DF_Total_Calories = 170
                        },
                        new
                        {
                            DietsD_Id = 2,
                            FoodsF_Id = 14,
                            DF_Frequency = "Daily",
                            DF_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3854),
                            DF_Recommended_Servings = "1-2 servings/day",
                            DF_Serving_Size = "1 cup cooked",
                            DF_Total_Calories = 35
                        },
                        new
                        {
                            DietsD_Id = 2,
                            FoodsF_Id = 15,
                            DF_Frequency = "Daily",
                            DF_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3855),
                            DF_Recommended_Servings = "1-2 servings/day",
                            DF_Serving_Size = "2 tablespoons",
                            DF_Total_Calories = 138
                        },
                        new
                        {
                            DietsD_Id = 3,
                            FoodsF_Id = 1,
                            DF_Frequency = "Daily",
                            DF_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3857),
                            DF_Recommended_Servings = "1 serving/day",
                            DF_Serving_Size = "1/2 avocado",
                            DF_Total_Calories = 160
                        },
                        new
                        {
                            DietsD_Id = 3,
                            FoodsF_Id = 2,
                            DF_Frequency = "Daily",
                            DF_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3859),
                            DF_Recommended_Servings = "1-2 servings/day",
                            DF_Serving_Size = "4 oz",
                            DF_Total_Calories = 94
                        },
                        new
                        {
                            DietsD_Id = 3,
                            FoodsF_Id = 3,
                            DF_Frequency = "Daily",
                            DF_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3861),
                            DF_Recommended_Servings = "2-3 servings/day",
                            DF_Serving_Size = "1/2 cup cooked",
                            DF_Total_Calories = 115
                        },
                        new
                        {
                            DietsD_Id = 3,
                            FoodsF_Id = 4,
                            DF_Frequency = "Daily",
                            DF_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3863),
                            DF_Recommended_Servings = "1-2 servings/day",
                            DF_Serving_Size = "1/2 cup cooked",
                            DF_Total_Calories = 135
                        },
                        new
                        {
                            DietsD_Id = 3,
                            FoodsF_Id = 5,
                            DF_Frequency = "Daily",
                            DF_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3864),
                            DF_Recommended_Servings = "1-2 servings/day",
                            DF_Serving_Size = "1 cup cooked",
                            DF_Total_Calories = 222
                        },
                        new
                        {
                            DietsD_Id = 3,
                            FoodsF_Id = 6,
                            DF_Frequency = "Daily",
                            DF_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3866),
                            DF_Recommended_Servings = "1-2 servings/day",
                            DF_Serving_Size = "1 cup cooked",
                            DF_Total_Calories = 41
                        },
                        new
                        {
                            DietsD_Id = 3,
                            FoodsF_Id = 7,
                            DF_Frequency = "Daily",
                            DF_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3868),
                            DF_Recommended_Servings = "1 serving/day",
                            DF_Serving_Size = "1 ounce",
                            DF_Total_Calories = 160
                        },
                        new
                        {
                            DietsD_Id = 3,
                            FoodsF_Id = 8,
                            DF_Frequency = "Daily",
                            DF_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3870),
                            DF_Recommended_Servings = "1 serving/day",
                            DF_Serving_Size = "1 medium potato",
                            DF_Total_Calories = 112
                        },
                        new
                        {
                            DietsD_Id = 3,
                            FoodsF_Id = 9,
                            DF_Frequency = "Daily",
                            DF_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3872),
                            DF_Recommended_Servings = "1-2 servings/day",
                            DF_Serving_Size = "1 cup cooked",
                            DF_Total_Calories = 55
                        },
                        new
                        {
                            DietsD_Id = 3,
                            FoodsF_Id = 10,
                            DF_Frequency = "Daily",
                            DF_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3873),
                            DF_Recommended_Servings = "1-2 servings/day",
                            DF_Serving_Size = "1 medium carrot",
                            DF_Total_Calories = 25
                        },
                        new
                        {
                            DietsD_Id = 3,
                            FoodsF_Id = 11,
                            DF_Frequency = "Daily",
                            DF_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3875),
                            DF_Recommended_Servings = "1-2 servings/day",
                            DF_Serving_Size = "1 tablespoon",
                            DF_Total_Calories = 120
                        },
                        new
                        {
                            DietsD_Id = 3,
                            FoodsF_Id = 12,
                            DF_Frequency = "Daily",
                            DF_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3877),
                            DF_Recommended_Servings = "1-2 servings/day",
                            DF_Serving_Size = "1/2 cup",
                            DF_Total_Calories = 120
                        },
                        new
                        {
                            DietsD_Id = 3,
                            FoodsF_Id = 13,
                            DF_Frequency = "Daily",
                            DF_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3879),
                            DF_Recommended_Servings = "1 serving/day",
                            DF_Serving_Size = "2 tablespoons",
                            DF_Total_Calories = 138
                        },
                        new
                        {
                            DietsD_Id = 3,
                            FoodsF_Id = 14,
                            DF_Frequency = "Daily",
                            DF_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3881),
                            DF_Recommended_Servings = "1-2 servings/day",
                            DF_Serving_Size = "1/2 cucumber",
                            DF_Total_Calories = 8
                        },
                        new
                        {
                            DietsD_Id = 3,
                            FoodsF_Id = 15,
                            DF_Frequency = "Daily",
                            DF_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3883),
                            DF_Recommended_Servings = "1-2 servings/day",
                            DF_Serving_Size = "1 cup cooked",
                            DF_Total_Calories = 35
                        },
                        new
                        {
                            DietsD_Id = 3,
                            FoodsF_Id = 16,
                            DF_Frequency = "Daily",
                            DF_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3884),
                            DF_Recommended_Servings = "1 serving/day",
                            DF_Serving_Size = "1/2 cup",
                            DF_Total_Calories = 100
                        });
                });

            modelBuilder.Entity("ExerciseXData_DietLibrary.Models.DietsModel", b =>
                {
                    b.Property<int>("D_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("D_Id"));

                    b.Property<string>("D_Cons_1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("D_Cons_2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("D_Cons_3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("D_Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("D_ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("D_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("D_Pros_1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("D_Pros_2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("D_Pros_3")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("D_Id");

                    b.ToTable("Diets");

                    b.HasData(
                        new
                        {
                            D_Id = 1,
                            D_ModifiedDate = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3569),
                            D_Name = "Mediterranean Diet"
                        },
                        new
                        {
                            D_Id = 2,
                            D_ModifiedDate = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3578),
                            D_Name = "Keto Diet"
                        },
                        new
                        {
                            D_Id = 3,
                            D_ModifiedDate = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3578),
                            D_Name = "Vegetarian Diet"
                        });
                });

            modelBuilder.Entity("ExerciseXData_DietLibrary.Models.FoodsModel", b =>
                {
                    b.Property<int>("F_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("F_Id"));

                    b.Property<int?>("F_Calories")
                        .HasColumnType("int");

                    b.Property<string>("F_Group")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("F_Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("F_Modified_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("F_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("F_Id");

                    b.ToTable("Foods");

                    b.HasData(
                        new
                        {
                            F_Id = 1,
                            F_Calories = 160,
                            F_Group = "Fruit",
                            F_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3697),
                            F_Name = "Avocado"
                        },
                        new
                        {
                            F_Id = 2,
                            F_Calories = 94,
                            F_Group = "Protein",
                            F_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3698),
                            F_Name = "Tofu"
                        },
                        new
                        {
                            F_Id = 3,
                            F_Calories = 115,
                            F_Group = "Legume",
                            F_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3699),
                            F_Name = "Lentils"
                        },
                        new
                        {
                            F_Id = 4,
                            F_Calories = 135,
                            F_Group = "Legume",
                            F_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3700),
                            F_Name = "Chickpeas"
                        },
                        new
                        {
                            F_Id = 5,
                            F_Calories = 222,
                            F_Group = "Grain",
                            F_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3701),
                            F_Name = "Quinoa"
                        },
                        new
                        {
                            F_Id = 6,
                            F_Calories = 41,
                            F_Group = "Vegetable",
                            F_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3702),
                            F_Name = "Spinach"
                        },
                        new
                        {
                            F_Id = 7,
                            F_Calories = 160,
                            F_Group = "Nut",
                            F_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3703),
                            F_Name = "Almonds"
                        },
                        new
                        {
                            F_Id = 8,
                            F_Calories = 112,
                            F_Group = "Vegetable",
                            F_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3704),
                            F_Name = "Sweet Potatoes"
                        },
                        new
                        {
                            F_Id = 9,
                            F_Calories = 55,
                            F_Group = "Vegetable",
                            F_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3705),
                            F_Name = "Broccoli"
                        },
                        new
                        {
                            F_Id = 10,
                            F_Calories = 25,
                            F_Group = "Vegetable",
                            F_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3706),
                            F_Name = "Carrots"
                        },
                        new
                        {
                            F_Id = 11,
                            F_Calories = 120,
                            F_Group = "Oil",
                            F_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3707),
                            F_Name = "Avocado Oil"
                        },
                        new
                        {
                            F_Id = 12,
                            F_Calories = 120,
                            F_Group = "Legume",
                            F_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3709),
                            F_Name = "Edamame"
                        },
                        new
                        {
                            F_Id = 13,
                            F_Calories = 138,
                            F_Group = "Seed",
                            F_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3710),
                            F_Name = "Chia Seeds"
                        },
                        new
                        {
                            F_Id = 14,
                            F_Calories = 8,
                            F_Group = "Vegetable",
                            F_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3779),
                            F_Name = "Cucumbers"
                        },
                        new
                        {
                            F_Id = 15,
                            F_Calories = 35,
                            F_Group = "Vegetable",
                            F_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3780),
                            F_Name = "Mushrooms"
                        },
                        new
                        {
                            F_Id = 16,
                            F_Calories = 100,
                            F_Group = "Dairy",
                            F_Modified_Date = new DateTime(2024, 12, 4, 22, 25, 32, 16, DateTimeKind.Local).AddTicks(3781),
                            F_Name = "Greek Yogurt"
                        });
                });

            modelBuilder.Entity("ExerciseXData_DietLibrary.Models.UsersDietsModel", b =>
                {
                    b.Property<int>("UD_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UD_Id"));

                    b.Property<string>("CustomDietName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("D_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UD_Frequency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UD_Modified_Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UD_ServingSize")
                        .HasColumnType("int");

                    b.Property<int?>("UD_TotalCalaroies")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UD_Id");

                    b.HasIndex("D_Id");

                    b.HasIndex("UserId");

                    b.ToTable("UsersDiets");
                });

            modelBuilder.Entity("ExerciseXData_UserLibrary.Models.UsersModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ConsentToDataCollection")
                        .HasColumnType("bit");

                    b.Property<string>("DietaryPreferences")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<int>("U_Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("U_Created_Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("U_Height_CM")
                        .HasColumnType("float");

                    b.Property<DateTime>("U_Last_Login")
                        .HasColumnType("datetime2");

                    b.Property<double>("U_Weight_KG")
                        .HasColumnType("float");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UsersModel");
                });

            modelBuilder.Entity("ExerciseXData_DietLibrary.Models.DietsFoodsModel", b =>
                {
                    b.HasOne("ExerciseXData_DietLibrary.Models.DietsModel", "Diets")
                        .WithMany("DietsFoods")
                        .HasForeignKey("DietsD_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExerciseXData_DietLibrary.Models.FoodsModel", "Foods")
                        .WithMany("DietsFoods")
                        .HasForeignKey("FoodsF_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diets");

                    b.Navigation("Foods");
                });

            modelBuilder.Entity("ExerciseXData_DietLibrary.Models.UsersDietsModel", b =>
                {
                    b.HasOne("ExerciseXData_DietLibrary.Models.DietsModel", "Diet")
                        .WithMany("UsersDiets")
                        .HasForeignKey("D_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExerciseXData_UserLibrary.Models.UsersModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diet");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ExerciseXData_DietLibrary.Models.DietsModel", b =>
                {
                    b.Navigation("DietsFoods");

                    b.Navigation("UsersDiets");
                });

            modelBuilder.Entity("ExerciseXData_DietLibrary.Models.FoodsModel", b =>
                {
                    b.Navigation("DietsFoods");
                });
#pragma warning restore 612, 618
        }
    }
}
