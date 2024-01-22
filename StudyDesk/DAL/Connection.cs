using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace BestPhonebookDesktopApp.DAL
{

    /// <summary>
    ///   the connection class.
    /// </summary>
    public static class Connection
    {


        /// <summary>
        ///   The connection string
        /// </summary>
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["WebAppSQLDatabaseConnection"].ConnectionString;
    }
}
