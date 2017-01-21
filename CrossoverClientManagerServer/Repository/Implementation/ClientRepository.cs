using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using CrossoverClientManagerServer.Models;
using CrossOverClientManagerEntities;

namespace CrossoverClientManagerServer.Repository.Implementation
{
    public class ClientRepository:IClientRepository
    {

        private IClientManagerContext context;

        public ClientRepository(IClientManagerContext bookContext)
        {
            context = bookContext; 
        }
        public void Add(ClientResponse b)
        {
            throw new NotImplementedException();
        }

        public void Edit(ClientResponse b)
        {
            throw new NotImplementedException();
        }

        public void Remove(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ClientResponse>> GetClients()
        {
            var clientList = new List<ClientResponse>();
            using (context)
            {
                var clients = await context.Clients.ToListAsync();

                foreach (var client in clients)
                {
                    ClientResponse clientResponse = new ClientResponse()
                    {
                        MachineName = client.MachineName,
                        IPAddresse = client.IPAddress,
                        OSName = client.OSType.OSNAme,
                        OSVersion = client.OSType.Version
                    };
                    clientList.Add(clientResponse);
                }
                return clientList.Any() ? clientList : Enumerable.Empty<ClientResponse>(); 
            }
        }

        public ClientResponse FindById(int Id)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<CrossOverClientManagerEntities.Model.OSType> GetOSType()
        {
            throw new NotImplementedException();
        }
    }
}