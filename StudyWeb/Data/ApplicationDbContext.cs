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
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// Designed for testing purposes
        /// </summary>
        public ApplicationDbContext()
        {

        }
        /// <summary>
        /// The Source
        /// </summary>
        public virtual DbSet<Source> Source { get; init; } = default!;

        /// <summary>
        /// The Note
        /// </summary>
        public virtual DbSet<Note> Note { get; init; } = default!;

        /// <summary>
        /// The SourceType
        /// </summary>
        public virtual DbSet<SourceType> SourceType { get; init; } = default!;
    }
}
