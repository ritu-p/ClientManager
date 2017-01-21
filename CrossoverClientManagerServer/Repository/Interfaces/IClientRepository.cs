using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossOverClientManagerEntities.Model;

namespace CrossoverClientManagerServer.Repository.Implementation
{
    interface IClientRepository
    {
        void Add(Client b);
        void Edit(Client b);
        void Remove(int Id);
        IEnumerable<Client> GetClients();
        Client FindById(int Id);
    }
}
