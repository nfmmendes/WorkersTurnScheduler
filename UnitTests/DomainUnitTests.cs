using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using WorkersTurnScheduler.Domain;

namespace UnitTests;

public class DomainUnitTests
{
    private static MemberInfo[] _properties = typeof(Contract).GetMembers(BindingFlags.Public | BindingFlags.Instance);
    private static RangeAttribute _weeklyHoursRange = _properties.First(x => x.Name.Equals("MinWeeklyHours")).GetCustomAttribute<RangeAttribute>();
    private static RangeAttribute _weeklyDaysRange = _properties.First(x => x.Name.Equals("MinWeeklyDays")).GetCustomAttribute<RangeAttribute>();
    private static RangeAttribute _dailyWorkingHoursRange = _properties.First(x => x.Name.Equals("MinDailyHours")).GetCustomAttribute<RangeAttribute>();

    public static IEnumerable<object[]> ValidWeeklyHours {
        get
        {
            return Enumerable.Range((int)_weeklyHoursRange.Minimum, (int)_weeklyHoursRange.Maximum + 1)
                             .Select(x => (new object[] { x }));
        }
    }   

    public static IEnumerable<object[]> InvalidWeeklyHours
    {
        get
        {
            var minimum = (int)_weeklyHoursRange.Minimum;
            var maximum = (int)_weeklyHoursRange.Maximum;
            return new object[] { minimum - 1, minimum - 3, maximum + 2 }.Select(x => (new object[] { x }));
        }
    }

    public static IEnumerable<object[]> ValidWorkingDays
    {
        get
        {
            return Enumerable.Range((int)_weeklyDaysRange.Minimum, (int)_weeklyDaysRange.Maximum + 1)
                             .Select(x => (new object[] { x }));
        }
    }

    public static IEnumerable<object[]> InvalidWorkingDays
    {
        get
        {
            int minimum = (int)_weeklyDaysRange.Minimum;
            int maximum = (int)_weeklyDaysRange.Maximum;

            return new object[] { minimum - 1, minimum - 3, maximum + 1 }.Select(x => (new object[] { x }));
        }
    }

    public static IEnumerable<object[]> ValidDailyWorkingHours
    {
        get
        {
            return Enumerable.Range((int)_dailyWorkingHoursRange.Minimum, (int)_dailyWorkingHoursRange.Maximum + 1)
                             .Select(x => (new object[] { x }));
        }
    }


    public static IEnumerable<object[]> InvalidDailyWorkingHours
    {
        get
        {
            var minimum = (int)_dailyWorkingHoursRange.Minimum;
            var maximum = (int)_dailyWorkingHoursRange.Maximum;
            return new object[] { minimum -1, minimum -3, maximum + 1 }.Select(x => (new object[] { x }));
        }
    }

    private IList<ValidationResult> ValidateModel(object model)
    {
        var validationResults = new List<ValidationResult>();
        var ctx = new ValidationContext(model, null, null);
        Validator.TryValidateObject(model, ctx, validationResults, true);
        return validationResults;
    }

    [Fact]
    public void TestContractDefaultConstructor()
    {
        Contract contract = new Contract();

        Assert.True(contract.ContractType == ContractType.Regular);
        Assert.True(contract.MinWeeklyHours == 0);
        Assert.True(contract.MaxWeeklyHours == 24 * 7);
        Assert.True(contract.MinWeeklyDays == 1);
        Assert.True(contract.MaxWeeklyDays == 7);
        Assert.True(contract.MinDailyHours == 1);
        Assert.True(contract.MaxDailyHours == 24);
    }

    [Fact]
    public void TestContractConstructorWithValidValues()
    {
        Contract contract = new Contract(ContractType.Freelance, new Tuple<int, int>(20, 40), new Tuple<int, int>(3, 4), new Tuple<int, int>(3, 6));

        Assert.True(contract.ContractType == ContractType.Freelance);
        Assert.True(contract.MinWeeklyHours == 20);
        Assert.True(contract.MaxWeeklyHours == 40);
        Assert.True(contract.MinWeeklyDays == 3);
        Assert.True(contract.MaxWeeklyDays == 4);
        Assert.True(contract.MinDailyHours == 3);
        Assert.True(contract.MaxDailyHours == 6);
    }

    [Theory]
    [MemberData(nameof(ValidWeeklyHours))]
    public void TestSetValidMinWeeklyHours(int value)
    {
        Contract contract = new Contract();

        contract.MinWeeklyHours = value;
        Assert.True(contract.MinWeeklyHours == value);
        Assert.DoesNotContain(ValidateModel(contract), x => x.MemberNames.Contains("MinWeeklyHours") && x.ErrorMessage != null);
    }

    [Theory]
    [MemberData(nameof(InvalidWeeklyHours))]
    public void TestSetInvalidMinWeeklyHours(int value)
    {
        Contract contract = new Contract();

        contract.MinWeeklyHours = value;
        Assert.Contains(ValidateModel(contract), x =>x.MemberNames.Contains("MinWeeklyHours") && x.ErrorMessage != null);
    }

    [Theory]
    [MemberData(nameof(ValidWeeklyHours))]
    public void TestSetValidMaxWeeklyHours(int value)
    {
        Contract contract = new Contract();

        contract.MaxWeeklyHours = value;
        Assert.True(contract.MaxWeeklyHours == value);
        Assert.DoesNotContain(ValidateModel(contract), x => x.MemberNames.Contains("MaxWeeklyHours") && x.ErrorMessage != null);
    }

    [Theory]
    [MemberData(nameof(InvalidWeeklyHours))]
    public void TestSetInvalidMaxWeeklyHours(int value)
    {
        Contract contract = new Contract();

        contract.MaxWeeklyHours = value;
        Assert.Contains(ValidateModel(contract), x => x.MemberNames.Contains("MaxWeeklyHours") && x.ErrorMessage != null);
    }

    [Theory]
    [MemberData(nameof(ValidWorkingDays))]
    public void TestSetValidMinWorkingDays(int value)
    {
        Contract contract = new Contract();

        contract.MinWeeklyDays = value;
        Assert.True(contract.MinWeeklyDays == value);
        Assert.DoesNotContain(ValidateModel(contract), x => x.MemberNames.Contains("MinWeeklyDays") && x.ErrorMessage != null);
    }

    [Theory]
    [MemberData(nameof(InvalidWorkingDays))]
    public void TestSetInvalidMinWorkingDays(int value)
    {
        Contract contract = new Contract();

        contract.MinWeeklyDays = value;
        Assert.Contains(ValidateModel(contract), x => x.MemberNames.Contains("MinWeeklyDays") && x.ErrorMessage != null);
    }

    [Theory]
    [MemberData(nameof(ValidWorkingDays))]
    public void TestSetValidMaxWorkingDays(int value)
    {
        Contract contract = new Contract();

        contract.MaxWeeklyDays = value;
        Assert.True(contract.MaxWeeklyDays == value);
        Assert.DoesNotContain(ValidateModel(contract), x => x.MemberNames.Contains("MaxWeeklyDays") && x.ErrorMessage != null);
    }

    [Theory]
    [MemberData(nameof(InvalidWorkingDays))]
    public void TestSetInvalidMaxWorkingDays(int value)
    {
        Contract contract = new Contract();

        contract.MaxWeeklyDays = value;
        Assert.Contains(ValidateModel(contract), x => x.MemberNames.Contains("MaxWeeklyDays") && x.ErrorMessage != null);
    }

    [Theory]
    [MemberData(nameof(ValidDailyWorkingHours))]
    public void TestSetValidMinDailyWorkingHours(int value)
    {
        Contract contract = new Contract();

        contract.MinDailyHours = value;
        Assert.True(contract.MinDailyHours == value);
        Assert.DoesNotContain(ValidateModel(contract), x => x.MemberNames.Contains("MinDailyHours") && x.ErrorMessage != null);
    }

    [Theory]
    [MemberData(nameof(InvalidDailyWorkingHours))]
    public void TestSetInvalidMinDailyWorkingHours(int value)
    {
        Contract contract = new Contract();

        contract.MinDailyHours = value;
        Assert.Contains(ValidateModel(contract), x => x.MemberNames.Contains("MinDailyHours") && x.ErrorMessage != null);
    }

    [Theory]
    [MemberData(nameof(ValidDailyWorkingHours))]
    public void TestSetValidMaxDailyWorkingHours(int value)
    {
        Contract contract = new Contract();

        contract.MaxDailyHours = value;
        Assert.True(contract.MaxDailyHours == value);
        Assert.DoesNotContain(ValidateModel(contract), x => x.MemberNames.Contains("MaxDailyHours") && x.ErrorMessage != null);
    }

    [Theory]
    [MemberData(nameof(InvalidDailyWorkingHours))]
    public void TestSetInvalidMaxDailyWorkingHours(int value)
    {
        Contract contract = new Contract();

        contract.MaxDailyHours = value;
        Assert.Contains(ValidateModel(contract), x => x.MemberNames.Contains("MaxDailyHours") && x.ErrorMessage != null);
    }

    [Theory]
    [InlineData(ContractType.Freelance)]
    [InlineData(ContractType.Regular)]
    [InlineData(ContractType.Temporary)]
    public void TestSetContractType(ContractType contractType)
    {
        Contract contract = new Contract();
        contract.ContractType = contractType;

        Assert.True(contract.ContractType == contractType);
    }
}