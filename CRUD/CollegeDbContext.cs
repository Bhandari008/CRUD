using CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD
{
    public class CollegeDbContext:DbContext
    {
        public CollegeDbContext(DbContextOptions<CollegeDbContext> options) : base(options)
        {

        }

        public DbSet<StudentModel> Students { get; set; }

        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StudentModel>().ToTable("Student");
            base.OnModelCreating(builder);
        }
    }
}
