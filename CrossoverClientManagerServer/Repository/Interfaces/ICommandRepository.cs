using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossoverClientManagerServer.Models;
using CrossOverClientManagerEntities.Model;

namespace CrossoverClientManagerServer.Repository.Implementation
{
   public interface ICommandRepository
    {

        Task<bool> Add(CommandResponse b);
        void Edit(Command b);
        void Remove(int Id);
        Task<IEnumerable<CommandResponse>> GetCommands();
          Task<IEnumerable<CommandResponse>> FindByClientId(int Id);
    }
}
