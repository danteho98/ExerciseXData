﻿// <auto-generated />
using System;
using ExerciseXData.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExerciseXData.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240928174929_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ExerciseXData.Models.Categories", b =>
                {
                    b.Property<int>("C_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("C_Id"), 1L, 1);

                    b.Property<string>("C_Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("C_Modified_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("C_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("C_Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ExerciseXData.Models.Diets", b =>
                {
                    b.Property<int>("D_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("D_Id"), 1L, 1);

                    b.Property<string>("D_Cons_1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("D_Cons_2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("D_Cons_3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("D_Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("D_Modified_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("D_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("D_Pros_1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("D_Pros_2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("D_Pros_3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("D_Total_Calories")
                        .HasColumnType("int");

                    b.Property<int?>("F_Amount")
                        .HasColumnType("int");

                    b.Property<string>("F_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("D_Id");

                    b.ToTable("Diets");
                });

            modelBuilder.Entity("ExerciseXData.Models.DietsFoods", b =>
                {
                    b.Property<int?>("D_Id")
                        .HasColumnType("int");

                    b.Property<int?>("F_Id")
                        .HasColumnType("int");

                    b.Property<int>("DF_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("DF_Modified_Date")
                        .HasColumnType("datetime2");

                    b.HasKey("D_Id", "F_Id");

                    b.HasIndex("F_Id");

                    b.ToTable("DietsFoods");
                });

            modelBuilder.Entity("ExerciseXData.Models.Exercises", b =>
                {
                    b.Property<int>("E_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("E_Id"), 1L, 1);

                    b.Property<int?>("C_Id")
                        .HasColumnType("int");

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

                    b.Property<string>("E_Image")
                        .HasColumnType("nvarchar(max)");

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
                });

            modelBuilder.Entity("ExerciseXData.Models.Foods", b =>
                {
                    b.Property<int>("F_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("F_Id"), 1L, 1);

                    b.Property<int?>("F_Calories")
                        .HasColumnType("int");

                    b.Property<string>("F_Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("F_Modified_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("F_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("F_Id");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("ExerciseXData.Models.Users", b =>
                {
                    b.Property<int>("U_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("U_Id"), 1L, 1);

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Height")
                        .HasColumnType("float");

                    b.Property<string>("Lifestyle_Condition_1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lifestyle_Condition_2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lifestyle_Condition_3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lifestyle_Condition_4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lifestyle_Condition_5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("U_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Weight")
                        .HasColumnType("float");

                    b.HasKey("U_Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ExerciseXData.Models.UsersDiets", b =>
                {
                    b.Property<int?>("U_Id")
                        .HasColumnType("int");

                    b.Property<int?>("D_Id")
                        .HasColumnType("int");

                    b.Property<int?>("Food_Calories")
                        .HasColumnType("int");

                    b.Property<int?>("Food_Name")
                        .HasColumnType("int");

                    b.Property<int?>("Food_Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("FoodsF_Id")
                        .HasColumnType("int");

                    b.Property<int?>("Total_Calaroies")
                        .HasColumnType("int");

                    b.Property<int>("UD_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("UD_Modified_Date")
                        .HasColumnType("datetime2");

                    b.HasKey("U_Id", "D_Id");

                    b.HasIndex("D_Id");

                    b.HasIndex("FoodsF_Id");

                    b.ToTable("UsersDiets");
                });

            modelBuilder.Entity("ExerciseXData.Models.UsersExercises", b =>
                {
                    b.Property<int>("U_Id")
                        .HasColumnType("int");

                    b.Property<int>("E_Id")
                        .HasColumnType("int");

                    b.Property<int?>("Duration")
                        .HasColumnType("int");

                    b.Property<int?>("Repetition")
                        .HasColumnType("int");

                    b.Property<int?>("Sets")
                        .HasColumnType("int");

                    b.Property<int>("UE_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("UE_Modify_Date")
                        .HasColumnType("datetime2");

                    b.HasKey("U_Id", "E_Id");

                    b.HasIndex("E_Id");

                    b.ToTable("UsersExercises");
                });

            modelBuilder.Entity("ExerciseXData.Models.DietsFoods", b =>
                {
                    b.HasOne("ExerciseXData.Models.Diets", "Diets")
                        .WithMany("DietsFoods")
                        .HasForeignKey("D_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExerciseXData.Models.Foods", "Foods")
                        .WithMany("DietsFoods")
                        .HasForeignKey("F_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diets");

                    b.Navigation("Foods");
                });

            modelBuilder.Entity("ExerciseXData.Models.Exercises", b =>
                {
                    b.HasOne("ExerciseXData.Models.Categories", "Categories")
                        .WithMany("Exercises")
                        .HasForeignKey("CategoriesC_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("ExerciseXData.Models.UsersDiets", b =>
                {
                    b.HasOne("ExerciseXData.Models.Diets", "Diets")
                        .WithMany("UsersDiets")
                        .HasForeignKey("D_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExerciseXData.Models.Foods", null)
                        .WithMany("UsersDiets")
                        .HasForeignKey("FoodsF_Id");

                    b.HasOne("ExerciseXData.Models.Users", "Users")
                        .WithMany("UsersDiets")
                        .HasForeignKey("U_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diets");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("ExerciseXData.Models.UsersExercises", b =>
                {
                    b.HasOne("ExerciseXData.Models.Exercises", "Exercises")
                        .WithMany("UsersExercises")
                        .HasForeignKey("E_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExerciseXData.Models.Users", "Users")
                        .WithMany("UsersExercises")
                        .HasForeignKey("U_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercises");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("ExerciseXData.Models.Categories", b =>
                {
                    b.Navigation("Exercises");
                });

            modelBuilder.Entity("ExerciseXData.Models.Diets", b =>
                {
                    b.Navigation("DietsFoods");

                    b.Navigation("UsersDiets");
                });

            modelBuilder.Entity("ExerciseXData.Models.Exercises", b =>
                {
                    b.Navigation("UsersExercises");
                });

            modelBuilder.Entity("ExerciseXData.Models.Foods", b =>
                {
                    b.Navigation("DietsFoods");

                    b.Navigation("UsersDiets");
                });

            modelBuilder.Entity("ExerciseXData.Models.Users", b =>
                {
                    b.Navigation("UsersDiets");

                    b.Navigation("UsersExercises");
                });
#pragma warning restore 612, 618
        }
    }
}
