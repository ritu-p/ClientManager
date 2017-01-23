using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossOverClientManager.Entities.Model;

namespace CrossOverClientManager.Entities
{
  public  class ClientManagerContext:DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<OSType> OS { get; set; } 
    }
}
