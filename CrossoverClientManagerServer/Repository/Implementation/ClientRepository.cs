using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using CrossoverClientManagerServer.Models;
using CrossOverClientManagerEntities;
using CrossOverClientManagerEntities.Model;

namespace CrossoverClientManagerServer.Repository.Implementation
{
    public class ClientRepository:IClientRepository
    {

        private IClientManagerContext context;
        static List<OSType> osTypes;

        public  ClientRepository(IClientManagerContext clientContext)
        {
            context = clientContext; 
        
        }
        public async Task<bool> Add(ClientResponse clientResponse)
        {
               
           Client client=  clientResponse.ToClientObject();
            context.Clients.AddOrUpdate(key=>key.ID,client);
            context.SaveChanges();
            return true;

        }

        public void Edit(ClientResponse clientResponse)
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


        public async Task<IEnumerable<CrossOverClientManagerEntities.Model.OSType>> GetOSType()
        {
            return await context.OS.ToListAsync();
        }
    }
}