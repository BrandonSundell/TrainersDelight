using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrainersDelight.Models;

namespace TrainersDelight.Data
{
    public class TrainersDelightContext : DbContext
    {
        public TrainersDelightContext (DbContextOptions<TrainersDelightContext> options) : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<ClientBFP> ClientBFPs { get; set; }
        public DbSet<ClientBMI> ClientBMIs { get; set; }
        public DbSet<ClientWeight> ClientWeights { get; set; }
        public DbSet<ClientGoals> ClientGoals { get; set; }
        public DbSet<TrainerNotes> TrainerNotes { get; set; }
        


    }
}
