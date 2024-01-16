namespace BestPhonebookApp.Models
{
    /// <summary>
    ///   The phonebook entry class.
    /// </summary>
    public class PhonebookEntry
    {
        /// <summary>
        ///   The Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///   The name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///   The phone number
        /// </summary>
        public string PhoneNumber { get; set; }


        /// <summary>
        ///   Initializes a new instance of the <see cref="PhonebookEntry" /> class.
        /// </summary>
        public PhonebookEntry()
        {

        }

    }
}
