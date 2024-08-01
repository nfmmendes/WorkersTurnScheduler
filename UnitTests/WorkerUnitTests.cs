using System;
using WorkersTurnScheduler.Domain;

namespace UnitTests;

public class WorkerUnitTests
{
    [Fact]
    public void TestSetName()
    {
        Worker worker = new Worker();
        string newName = "New name";

        worker.Name = newName;
        Assert.Equal(worker.Name, newName);
    }

    [Fact]
    public void TestSetSurname()
    {
        Worker worker = new Worker();
        string newSurname = "Newsurname";

        worker.Surname = newSurname;
        Assert.Equal(worker.Surname, newSurname);
    }

    [Fact]
    public void TestConstructorWithoutContract()
    {
        Worker worker = new Worker("Name", "Surname");

        Assert.Equal("Name", worker.Name);
        Assert.Equal("Surname", worker.Surname);
        Assert.False(worker.HasContract);
    }

    [Fact]
    public void TestConstructorWithContract() {
        Worker worker = new Worker("Name", "Surname", new Contract()
        {
            ContractType = ContractType.Freelance,
            MaxDailyHours = 8,
            MinDailyHours = 6
        });

        Assert.Equal("Name", worker.Name);
        Assert.Equal("Surname", worker.Surname);
        Assert.True(worker.HasContract);
        Assert.Equal(ContractType.Freelance, worker.Contract?.ContractType);
        Assert.Equal(8, worker.Contract?.MaxDailyHours);
        Assert.Equal(6, worker.Contract?.MinDailyHours);
    }
}
