using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudyWeb.Models;

namespace StudyWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Source> Source { get; set; } = default!;

        public DbSet<Note> Note { get; set; } = default!;

        public DbSet<SourceType> SourceType { get; set; } = default!;
    }
}
