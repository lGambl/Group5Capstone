using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestPhonebookDesktopApp.Model
{

    /// <summary>
    ///   The phonebook entry class.
    /// </summary>
    public class PhonebookEntry
    {

        //public int Id { get; set; }


        /// <summary>
        ///   the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///   The phone number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        ///   Creates a Phonebook Entry object.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phoneNumber"></param>
        public PhonebookEntry(string name, string phoneNumber)
        {
            this.Name = name;
            this.PhoneNumber = phoneNumber;
        }

    }
}
