using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossOverClientManagerEntities.Model;

namespace CrossoverClientManagerServer.Repository.Implementation
{
    interface ICommandRepository
    {

        void Add(Command b);
        void Edit(Command b);
        void Remove(int Id);
        IEnumerable<Command> GetClients();
        Command FindById(int Id);
    }
}
