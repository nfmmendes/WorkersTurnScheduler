using System.ComponentModel.DataAnnotations;

namespace WorkersTurnScheduler.Domain
{
    /// <summary>
    /// Enum containing the types of contract.
    /// </summary>
    public enum ContractType
    {
        Temporary,
        Freelance,
        Regular
    };

    /// <summary>
    /// Class <c> Contract </c> models an employee contract core information.
    /// </summary>
    public class Contract
    {
        /// <value>
        /// The contract id.
        /// </value>
        [Required, Key]
        public Guid Id { get; private set; }

        /// <value>
        /// The contract type.
        /// </value>
        public ContractType ContractType { get; set; } = ContractType.Regular;

        /// <value>
        /// The maximum number of working hours during a week. 
        /// </value>
        [Required]
        [Range(minimum: 0, maximum: 24*7, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int MaxWeeklyHours { get; set; } = 24 * 7;

        /// <value>
        /// The minimum number of working hours during a week. 
        /// </value>
        [Required]
        [Range(minimum:0, maximum: 24*7, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int MinWeeklyHours { get; set; } = 0;

        /// <value>
        /// The maximum number of working days in a week. 
        /// </value>
        [Required]
        [Range(minimum:0, maximum:7, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int MaxWeeklyDays { get; set; } = 7;

        /// <value>
        /// The minimum number of working days in a week. 
        /// </value>
        [Required]
        [Range(minimum:0, maximum: 7, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int MinWeeklyDays { get; set; } = 1;

        /// <value>
        /// The maximum number of working hours in a day.
        /// </value>
        [Required]
        [Range(minimum:0, maximum: 24, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int MaxDailyHours { get; set; } = 1;

        /// <value>
        /// The minimum number of working hours in a day.
        /// </value>
        [Required]
        [Range (minimum:0, maximum: 24, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int MinDailyHours { get; set; } = 1;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="contractType"> Contract type. </param>
        /// <param name="weeklyHoursInterval"> The minimum and maximum number of working hours during a week. </param>
        /// <param name="weeklyDays"> The minimum and maximum number of working days in a week. </param>
        /// <param name="dailyHours"> The minimum and maximum number of working hours in a day. </param>
        public Contract(ContractType contractType, Tuple<int, int> weeklyHoursInterval, Tuple<int, int> weeklyDays, Tuple<int, int> dailyHours) {
            ContractType = contractType;
            MinWeeklyHours = weeklyHoursInterval.Item1;
            MaxWeeklyHours = weeklyHoursInterval.Item2;
            MinWeeklyDays = weeklyDays.Item1;
            MaxWeeklyDays = weeklyDays.Item2;
            MinDailyHours = dailyHours.Item1;
            MaxDailyHours = dailyHours.Item2;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Contract() { }
    }
}
