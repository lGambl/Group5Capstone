using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BestPhonebookDesktopApp.Model;
using MySql.Data.MySqlClient;

namespace BestPhonebookDesktopApp.DAL
{

    /// <summary>
    ///   The Phonebook data access layer
    /// </summary>
    internal class PhonebookDAL
    {

        /// <summary>
        ///   Gets all entries.
        /// </summary>
        /// <returns>
        ///   List of all phonebook entries.
        /// </returns>
        public static List<PhonebookEntry> GetAllEntries()
        {
            List<PhonebookEntry> entries = new List<PhonebookEntry>();
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            const string query = "select * from PhonebookEntry";
            using var command = new MySqlCommand(query, connection);

            using var reader = command.ExecuteReader();
            var nameOrdinal = reader.GetOrdinal("name");
            var phoneNumberOrdinal = reader.GetOrdinal("phoneNumber");

            while (reader.Read())
            {
                entries.Add(new PhonebookEntry(reader.GetString(nameOrdinal), reader.GetString(phoneNumberOrdinal)));
            }

            return entries;
        }


        /// <summary>
        ///   Gets the name of the entry by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>
        ///   The phonebook entry that contains the searched name
        /// </returns>
        public static PhonebookEntry GetEntryByName(string name)
        {
            PhonebookEntry entry = null;
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            const string query = "select * from PhonebookEntry where name contains @name";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@name", MySqlDbType.String).Value = name;

            using var reader = command.ExecuteReader();
            var nameOrdinal = reader.GetOrdinal("name");
            var phoneNumberOrdinal = reader.GetOrdinal("phoneNumber");

            while (reader.Read())
            {
                entry = new PhonebookEntry(reader.GetString(nameOrdinal), reader.GetString(phoneNumberOrdinal));
            }

            return entry;
        }

    }
}
