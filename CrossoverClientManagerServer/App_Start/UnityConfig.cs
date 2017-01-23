using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CrossoverClientManagerServer.Repository.Implementation;
using CrossOverClientManagerEntities;
using Microsoft.Practices.Unity;
using Unity.WebApi;

namespace CrossoverClientManagerServer.App_Start
{
    public static class UnityConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
			var container = new UnityContainer();

            //Dependency Resolution
            container.RegisterType<IClientRepository, ClientRepository>();
            container.RegisterType<ICommandRepository, CommandRepository>();
            container.RegisterType<IClientManagerContext, ClientManagerContext>();

            configuration.DependencyResolver = new UnityDependencyResolver(container);      
            
        }
    }
}
