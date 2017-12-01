using project1.Models;
using Microsoft.EntityFrameworkCore;

namespace project1.Models {
    public class ProjectContext : DbContext {
            public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) { }
            public DbSet<User> login { get; set; }
        }
}