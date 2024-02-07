using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudyWeb.Models;

namespace StudyWeb.Data;

/// <summary>
///     The Database Context
/// </summary>
/// <remarks>
///     The database context
/// </remarks>
/// <param name="options"></param>
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
{
    #region Properties

    /// <summary>
    ///     The Source
    /// </summary>
    public DbSet<Source> Source { get; init; } = default!;

    /// <summary>
    ///     The Note
    /// </summary>
    public DbSet<Note> Note { get; init; } = default!;

    /// <summary>
    ///     The SourceType
    /// </summary>
    public DbSet<SourceType> SourceType { get; init; } = default!;

    #endregion
}