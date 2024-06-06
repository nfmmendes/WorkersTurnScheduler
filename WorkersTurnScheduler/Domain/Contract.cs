using System.ComponentModel.DataAnnotations;

namespace WorkersTurnScheduler.Domain
{
    public enum ContractType
    {
        Temporary,
        Freelance,
        Regular
    };

    public class Contract
    {
        public UInt128 Id { get; private set; }

        public ContractType ContractType { get; private set; } = ContractType.Regular;

        [Required]
        [Range(minimum: 0, maximum: 24*7, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int MaxWeeklyHours { get; set; } = 24 * 7;

        [Required]
        [Range(minimum:0, maximum: 24*7, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int MinWeeklyHours { get; set; } = 0;

        [Required]
        [Range(minimum:0, maximum:7, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int MaxWeeklyDays { get; set; } = 7;

        [Required]
        [Range(minimum:0, maximum: 7, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int MinWeeklyDays { get; set; } = 1;

        [Required]
        [Range(minimum:0, maximum: 24, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int MaxDailyHours { get; set; } = 1;

        [Required]
        [Range (minimum:0, maximum: 24, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int MinDailyHours { get; set; } = 1;


        public Contract(ContractType contractType, Tuple<int, int> weeklyHoursInterval, Tuple<int, int> weeklyDays, Tuple<int, int> dailyHours) { 
            ContractType = contractType;
        }
    }
}
