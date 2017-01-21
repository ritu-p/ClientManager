using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossoverClientManagerServer.Models;
using CrossOverClientManagerEntities.Model;

namespace CrossoverClientManagerServer.Repository.Implementation
{
  public  interface IClientRepository
    {
        Task<bool> Add(ClientResponse b);
        void Edit(ClientResponse b);
        void Remove(int Id);
        Task<IEnumerable<ClientResponse>> GetClients();
        Task<IEnumerable<OSType>> GetOSType();
        ClientResponse FindById(int Id);

    }
}
