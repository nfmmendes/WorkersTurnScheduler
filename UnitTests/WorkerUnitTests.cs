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
}
