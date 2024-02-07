using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudyWeb.Models;

namespace StudyWeb.Data
{
    /// <summary>
    /// The Database Context
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext
    {
        /// <summary>
        /// The database context
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        /// <summary>
        /// The Source
        /// </summary>
        public DbSet<Source> Source { get; set; } = default!;

        /// <summary>
        /// The Note
        /// </summary>
        public DbSet<Note> Note { get; set; } = default!;

        /// <summary>
        /// The SourceType
        /// </summary>
        public DbSet<SourceType> SourceType { get; set; } = default!;
    }
}
