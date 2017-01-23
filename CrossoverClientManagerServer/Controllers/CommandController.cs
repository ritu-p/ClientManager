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
    public class CommandController : ApiController
    {

        
        private ICommandRepository commandRepository;
 //TODO remove this but load it only once;
        private static List<OSType> osList;
        public CommandController(ICommandRepository repository)
        {
            commandRepository = repository;
        }


        [HttpGet]
        // GET api/Command/GetCommands
        public async Task<IEnumerable<CommandResponse>> GetCommands()
        {
            var commands = await commandRepository.GetCommands();
            return commands;
        }
           [HttpGet]
        // GET api/Command/GetCommands/clientid
        public async Task<IEnumerable<CommandResponse>> GetCommands(int clientid)
        {
            var commands = await commandRepository.FindByClientId(clientid);
            return commands;
        }

           // POST api/Command/Post
           public async Task<IHttpActionResult> Post([FromBody]CommandResponse command)
        {

            bool postStatus = await commandRepository.Add(command);
            return Ok(postStatus);
        }


           public async Task<IHttpActionResult> MapClients([FromBody]CommandResponse command)
           {

               bool postStatus = await commandRepository.Add(command);
               return Ok(postStatus);
           }
        // PUT api/command/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/command/5
        public void Delete(int id)
        {
        }
    }
}
