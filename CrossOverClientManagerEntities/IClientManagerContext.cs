using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossOverClientManagerEntities.Model;

namespace CrossOverClientManagerEntities
{
    public interface IClientManagerContext:IDisposable
    {

         DbSet<Client> Clients { get; set; }
         DbSet<OSType> OS { get; set; }
         DbSet<Command> Commands { get; set; }
         DbSet<CommandClientMapper> CommandClientMapper { get; set; }
         DbSet<CommandOutput> CommandOutputs { get; set; }
    }
}
