using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossOverClientManagerEntities;
using CrossOverClientManagerEntities.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrossoverClientManagerServer.Tests
{
    [TestClass]
  public  class EntitiesTest
    {
        [TestMethod]
        public void TestInsert()
        {

            using (var db = new ClientManagerContext())
            {
             

                var os = new OSType() { OSNAme = "Windows",Version = "10"};
                db.OS.Add(os);
                var client= new Client() {MachineName = "CrossoverMachine" ,OSType = os,IPAddress = "10.22.121.22"};
                db.Clients.Add(client);
                db.SaveChanges();

                // Display all Blogs from the database 
                var query = from b in db.OS
                            orderby b.OSNAme
                            select b;


                foreach (var item in query)
                {
                   Assert.IsNotNull(item);
                }

            
            }
        }
    }
}
