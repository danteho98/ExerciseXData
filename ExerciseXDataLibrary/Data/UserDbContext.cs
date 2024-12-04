
using ExerciseXData_UserLibrary.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;



namespace ExerciseXData_UserLibrary.Data
{
    public class UserDbContext : IdentityDbContext<UsersModel>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) {}

        public DbSet<UsersModel> User {  get; set; }
       
        //public DbSet<SecurityQuestionModel> SecurityQuestions { get; set; }
       // public DbSet<UserSecurityQuestionModel> UserSecurityQuestions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder); // Ensures the Identity configurations are applied


           
            modelBuilder.Entity<UsersModel>()
                .Property(u => u.U_UserGender)
                .HasConversion<string>(); // Convert enum to string in DB



            // Configure IdentityUser mappings if required
            modelBuilder.Entity<IdentityUser>()
                .HasIndex(iu => iu.Email)
                .IsUnique();

            //modelBuilder.Entity<SecurityQuestionModel>()
                //.HasKey(sq => sq.SQ_Id);

            //modelBuilder.Entity<UserSecurityQuestionModel>(entity =>
            //{
            //    // Configure composite primary key
            //    entity.HasKey(usq => new { usq.U_Id, usq.SecurityQuestionId });

            //    // Relationship with UsersModel
            //    entity.HasOne(usq => usq.Users)
            //          .WithMany(u => u.UserSecurityQuestions)
            //          .HasForeignKey(usq => usq.U_Id)
            //          .OnDelete(DeleteBehavior.Cascade);

            //    entity.HasOne(usq => usq.UserSecurityQuestions)
            //          .WithMany()
            //          .HasForeignKey(usq => usq.SecurityQuestionId)
            //          .OnDelete(DeleteBehavior.Cascade);
            //});
        }
    }
}
