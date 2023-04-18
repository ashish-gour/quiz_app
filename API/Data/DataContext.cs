using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<User>? Users { get; set; }
        public DbSet<Exam>? Exams { get; set; }
        public DbSet<Question>? Questions { get; set; }
        public DbSet<Option>? Options { get; set; }
        public DbSet<Result>? Results { get; set; }
    }
}
