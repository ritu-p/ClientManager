using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossOverClientManagerEntities.Model;

namespace CrossOverClientManagerEntities
{
   public class ClientManagerContext :DbContext,IClientManagerContext
    {

        public DbSet<Client> Clients { get; set; }
        public DbSet<OSType> OS { get; set; }
        public DbSet<Command> Commands { get; set; }
        public DbSet<CommandClientMapper> CommandClientMapper { get; set; }
        public DbSet<CommandOutput> CommandOutputs { get; set; }
    }
}
