using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkersTurnScheduler.Domain
{
    /// <summary>
    /// Class <c> Worker </c> contains worker personal and contractual data. 
    /// </summary>
    public class Worker
    {
        [Required, Key]
        public Guid Id { get; private set; }

        /// <value>
        /// Worker name. 
        /// </value>
        [DisplayName("Name")]
        [Required]
        public string Name { get; set; }

        /// <value>
        /// Worker surnname. 
        /// </value>
        [DisplayName("Surname")]
        [Required]
        public string Surname { get; set; }

        /// <value>
        /// If the worker is currently active. 
        /// </value>
        [DisplayName("Is active")]
        public bool IsActive { get; set; }

        [DisplayName("Has contract")]
        [NotMapped]
        public bool HasContract
        {
            get { return Contract != null; }
        }

        /// <summary>
        /// The worker contract.
        /// </summary>
        public Contract? Contract { get; set; }

        private static UInt128 LastId { get; set; }

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="name"> The worker name. </param>
        /// <param name="surname">The worker surname. </param>
        /// <param name="contract"> The worker contract. </param>
        public Worker(string name, string surname, Contract? contract=null)
        {
            Name = name;
            Surname = surname;
            IsActive = contract != null;
            Contract = contract;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Worker() {
            Name = "";
            Surname = "";
            Contract = new Contract();
        }
    }
}
