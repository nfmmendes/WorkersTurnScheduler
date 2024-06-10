﻿using WorkersTurnScheduler.Domain;

namespace WorkersTurnScheduler.Services
{
    public interface IWorkerRepository
    {
        List<Worker> GetAllWorkers(); 

        Worker GetWorker(UInt128 id);
    }
}