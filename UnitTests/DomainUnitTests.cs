using WorkersTurnScheduler.Domain;

namespace UnitTests;

public class DomainUnitTests
{
    [Fact]
    public void TestContractDefaultConstructor()
    {
        Contract contract = new Contract();

        Assert.True(contract.ContractType == ContractType.Regular);
        Assert.True(contract.MinWeeklyHours == 0);
        Assert.True(contract.MaxWeeklyHours == 24*7);
        Assert.True(contract.MinWeeklyDays == 1);
        Assert.True(contract.MaxWeeklyDays == 7);
        Assert.True(contract.MinDailyHours == 1);
        Assert.True(contract.MaxDailyHours == 24);
    }

    [Fact]
    public void TestContractConstructorWithValidValues()
    {
        Contract contract = new Contract(ContractType.Freelance, new Tuple<int, int>(20, 40), new Tuple<int,int>(3, 4), new Tuple<int,int>(3, 6)); 

        Assert.True(contract.ContractType == ContractType.Freelance);
        Assert.True(contract.MinWeeklyHours == 20);
        Assert.True(contract.MaxWeeklyHours == 40);
        Assert.True(contract.MinWeeklyDays == 3);
        Assert.True(contract.MaxWeeklyDays == 4);
        Assert.True(contract.MinDailyHours == 3);
        Assert.True(contract.MaxDailyHours == 6);
    }
}