using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        public string Name { get; private set; }

        /// <value>
        /// Worker surnname. 
        /// </value>
        [Required]
        public string Surname { get; private set; }

        /// <value>
        /// If the worker is currently active. 
        /// </value>
        public bool IsActive { get; private set; }

        /// <summary>
        /// The worker contract.
        /// </summary>
        public Contract? Contract { get; private set; }

        private static UInt128 LastId { get; set; }

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="name"> The worker name. </param>
        /// <param name="surname">The worker surname. </param>
        /// <param name="contract"> The worker contract. </param>
        public Worker(string name, string surname, Contract? contract)
        {
            Name = name;
            Surname = surname;
            IsActive = contract != null;
            Contract = contract;
        }
    }
}
