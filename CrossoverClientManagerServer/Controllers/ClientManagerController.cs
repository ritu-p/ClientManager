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
        [HttpPost]
        // POST api/values
        public async Task<IHttpActionResult> Post([FromBody]ClientResponse client)
        {
            String errorString;
            var osEnum=await clientRepository.GetOSType();
            var osList = osEnum.ToList();
            bool validationResult= client.Validate(osList, out errorString);
            if(validationResult)
            {
              await   clientRepository.Add(client);
              return Ok(true);
            }

            return InternalServerError(new Exception(errorString));

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