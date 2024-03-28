using Microsoft.EntityFrameworkCore;

namespace StudyWeb.Data;

/// <summary>
///     A service for interacting with the database.
/// </summary>
public interface IDatabaseService
{
    #region Methods

    /// <summary>
    ///     Executes the given SQL query.
    /// </summary>
    /// <param name="sql"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public Task<int> ExecuteSqlRawAsync(string sql, params object[] parameters);

    #endregion
}

/// <summary>
///     A concrete implementation of the <see cref="IDatabaseService" /> interface.
/// </summary>
public class DatabaseService : IDatabaseService
{
    #region Data members

    private readonly ApplicationDbContext _context;

    #endregion

    #region Constructors

    /// <summary>
    ///     The default constructor for the <see cref="DatabaseService" /> class.
    /// </summary>
    /// <param name="context"></param>
    public DatabaseService(ApplicationDbContext context)
    {
        this._context = context;
    }

    #endregion

    #region Methods

    /// <inheritdoc />
    public async Task<int> ExecuteSqlRawAsync(string sql, params object[] parameters)
    {
        return await this._context.Database.ExecuteSqlRawAsync(sql, parameters);
    }

    #endregion
}