using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using CrossoverClientManagerServer.Models;
using CrossoverClientManagerServer.Repository.Implementation;
using CrossOverClientManagerEntities.Model;

namespace CrossoverClientManagerServer.Controllers
{
    
    public class ClientManagerController : ApiController
    {
        private IClientRepository clientRepository;
 //TODO remove this but load it only once;
        private static List<OSType> osList;
        public ClientManagerController(IClientRepository repository)
        {
            clientRepository = repository;
        }

           [HttpGet]
        // GET api/ClientManager/GetClients
        public async Task<IEnumerable<ClientResponse>> GetClients()
        {
          var clients= await  clientRepository.GetClients();
          return clients;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}