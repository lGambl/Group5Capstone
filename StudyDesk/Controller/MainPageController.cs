﻿using Microsoft.Data.SqlClient;
using StudyDesk.Model;

namespace StudyDesk.Controller;

/// <summary>
///     Controller for the main page.
/// </summary>
public class MainPageController
{
    private const string ConnectionString =
        "Server=(localdb)\\mssqllocaldb;Database=aspnet-BestPhonebookApp-0fc62a5a-c4b5-4292-9de7-2d743b650400;Trusted_Connection=True;MultipleActiveResultSets=true";
    #region Properties

    /// <summary>
    ///     Gets or sets the sources of the logged-in user.
    /// </summary>
    /// <value>
    ///     The sources as a collection of Source objects.
    /// </value>
    public IList<Source> Sources { get; private set; }

    public AuthService AuthService { get; set; }

    #endregion

    /// <summary>
    /// Initializes a new instance of the <see cref="MainPageController"/> class.
    /// </summary>
    public MainPageController(AuthService auth)
    {
        
        this.AuthService = auth;
        this.Sources = this.AuthService.GetSources().Result.ToList();
    }



    #region Methods

    /// <summary>
    ///     Adds as source under the logged-in user.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="type">The type.</param>
    /// <param name="link">The link.</param>
    /// <precondition>
    ///     name != null AND !name.isEmptyOrBlank
    ///     sourceType.isOfTypeEnum<see cref="SourceType" />() AND
    ///     link != null AND !link.isEmptyOrBlank
    /// </precondition>
    /// <returns>True if addition is successful, false otherwise.</returns>
    public bool AddSource(string name, SourceType type, string link)
    {
        return true;
    }

    #endregion
}