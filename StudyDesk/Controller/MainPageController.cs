using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using StudyDesk.Model;

namespace StudyDesk.Controller
{
    /// <summary>
    /// Controller for the main page.
    /// </summary>
    public class MainPageController
    {
        private const string ConnectionString = "Server=(localdb)\\\\mssqllocaldb;Database=aspnet-BestPhonebookApp-0fc62a5a-c4b5-4292-9de7-2d743b650400;Trusted_Connection=True;MultipleActiveResultSets=true";

        /// <summary>
        /// Gets or sets the Id of the logged-in user.
        /// </summary>
        /// <value>
        /// The logged in identifier.
        /// </value>
        public string LoggedInId { get; private set; }

        /// <summary>
        /// Gets or sets the sources of the logged-in user.
        /// </summary>
        /// <value>
        /// The sources as a collection of Source objects.
        /// </value>
        public IList<Source> Sources { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainPageController"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <precondition>id != null</precondition>
        public MainPageController(string id)
        {
            this.LoggedInId = id ?? throw new ArgumentNullException(nameof(id));
            this.Sources = this.getSources();
        }

        private IList<Source> getSources()
        {
            var sources = new List<Source>();
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand("SELECT * FROM Sources WHERE UserId = @UserId", connection);
            command.Parameters.AddWithValue("@UserId", this.LoggedInId);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                sources.Add(new Source(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                    (SourceType)reader.GetInt32(3), this.LoggedInId));
            }
            return sources;
        }




    }
}
