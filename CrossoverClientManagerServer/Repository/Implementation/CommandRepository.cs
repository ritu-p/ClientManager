using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using CrossoverClientManagerServer.Models;
using CrossOverClientManagerEntities;
using CrossOverClientManagerEntities.Model;

namespace CrossoverClientManagerServer.Repository.Implementation
{
    public class CommandRepository:ICommandRepository
    {

         private IClientManagerContext context;
         private List<OSType> osType;

         public  CommandRepository(IClientManagerContext clientContext)
        {
            context = clientContext;

        
        }

    /*   public async List<OSType> GetOSType
        {
            get
            {
                if(osType==null || osType.Count()==0)
                {
                    var os=await context.OS.ToListAsync();
                    return 
                }
            }

        }*/

        public async Task<bool> Add(CommandResponse command)
        {

            var os = await context.OS.ToListAsync();
          var osType = os.Find(r => (r.OSNAme == command.OSName && r.Version ==command.OSVersion));
          if (osType == null)
              return false;
            Command commmand = command.ToCommandObject(osType);
            context.Commands.AddOrUpdate(key => key.CommandID, commmand);
            context.SaveChanges();
            return true;

        }

        public void Edit(Command command)
        {
            throw new NotImplementedException();
        }

        public void Remove(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CommandResponse>> GetCommands()
        {
            var commandList = new List<CommandResponse>();
            using (context)
            {
                var commands = await context.Commands.ToListAsync();

                foreach (var command in commands)
                {
                    CommandResponse commandResponse = new CommandResponse()
                    {
                        Commandstring = command.CommandString,
                        parameters =command.Parameters.Split(",".ToCharArray(),StringSplitOptions.RemoveEmptyEntries),
                        OSName = command.OSType.OSNAme,
                        OSVersion = command.OSType.Version
                    };
                    commandList.Add(commandResponse);
                }
                return commandList.Any() ? commandList : Enumerable.Empty<CommandResponse>();
            }
        }

        public async Task<IEnumerable<CommandResponse>> FindByClientId(int clientId)
        {
             var commandList = new List<CommandResponse>();
             using (context)
             {
                 var commands = from com in context.Commands join m in context.CommandClientMapper on com.CommandID equals m.CommandID where m.ID == clientId select com;
            
                 
                 foreach (var command in commands)
                 {
                     CommandResponse commandResponse = new CommandResponse()
                     {
                         Commandstring = command.CommandString,
                         parameters = command.Parameters.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries),
                         OSName = command.OSType.OSNAme,
                         OSVersion = command.OSType.Version
                     };
                     commandList.Add(commandResponse);
                 }
                 return commandList.Any() ? commandList : Enumerable.Empty<CommandResponse>();
             }
        }
    }
}