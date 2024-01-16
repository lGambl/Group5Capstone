using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BestPhonebookDesktopApp.DAL;
using BestPhonebookDesktopApp.Model;

namespace BestPhonebookDesktopApp.ViewModel
{

    /// <summary>
    ///   The Phonebook View Model
    /// </summary>
    public class PhonebookViewModel
    {

        /// <summary>
        ///   Gets the name of the entry by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>
        ///   The phonebook entry matching the name
        /// </returns>
        public static PhonebookEntry GetEntryByName(string name)
        {
            return PhonebookDAL.GetEntryByName(name);
        }


        /// <summary>
        ///   Gets all entries.
        /// </summary>
        /// <returns>
        ///   A list of all phonebook entries
        /// </returns>
        public static List<PhonebookEntry> GetAllEntries()
        {
            return PhonebookDAL.GetAllEntries();
        }

    }
}
