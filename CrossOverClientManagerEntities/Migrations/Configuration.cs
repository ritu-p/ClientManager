using CrossOverClientManagerEntities.Model;

namespace CrossOverClientManagerEntities.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CrossOverClientManagerEntities.ClientManagerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CrossOverClientManagerEntities.ClientManagerContext context)
        {
            var OSWindows = new OSType()
            {
                OSNAme = "Windows",
                Version = "8.1"
            };

            context.OS.AddOrUpdate(key => key.OSID, OSWindows);
            var Client1 = new Client()
            {
                MachineName = "CrossoverMachine1",
                OSType = OSWindows,
                IPAddress = "10.22.122.21"

            };
            var command1 = new Command()
            {
                CommandString = "ping",
                Parameters = "ipaddress"

            };
            context.Commands.AddOrUpdate(key => key.CommandID, command1);
            context.Clients.AddOrUpdate(key => key.ID, Client1);
            context.SaveChanges();
        }
    }
}
