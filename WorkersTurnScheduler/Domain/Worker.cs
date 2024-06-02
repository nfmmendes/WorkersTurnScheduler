﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WorkersTurnScheduler.Domain
{
    public class Worker
    {
        [Required, Key]
        public UInt128 Id { get; private set; }

        [Required]
        public string Name { get; private set; }

        [Required]
        public string Surname { get; private set; }

        public bool IsActive { get; private set; }

        private static UInt128 LastId { get; set; }


        static Worker()
        {
            LastId = 0;
        }

        public Worker(string name, string surname)
        {
            LastId += 1;
            Id = LastId;
            Name = name;
            Surname = surname;
        }
    }
}