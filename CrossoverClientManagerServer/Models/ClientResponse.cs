using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossOverClientManagerEntities.Model;
using Newtonsoft.Json;

namespace CrossoverClientManagerServer.Models
{
    public class ClientResponse
    {

       // [JsonProperty("client_id")]
       // public int ClientId { get; set; }

        [JsonProperty("MachineName")]
        public string MachineName { get; set; }

        [JsonProperty("OSName")]
        public string OSName { get; set; }
        [JsonProperty("OSVersion")]
        public string OSVersion { get; set; }

        [JsonProperty("IPAddresse")]
        public string IPAddresse { get; set; }

        private OSType osType;

      public Client ToClientObject()
       {
           Client client = new Client() { MachineName = this.MachineName, OSType = this.osType, IPAddress = this.IPAddresse };
           return client;
       }

        public bool Validate(List<OSType> os,out String errorString)
        {
            errorString = null;
            if (!ValidateIPv4(IPAddresse))
            {
                errorString = "Invalid IP";
                return false;
            }
            if (!ValidateOS(os))
            {
                errorString = "Invalid OS";
                return false;
            }
            return true;
        }

        private bool ValidateOS(List<OSType> os)
        {
            osType = os.Find(r => (r.OSNAme == OSName && r.Version == OSVersion));
            if (osType == null)
                return false;
            return true;

        }
        private bool ValidateIPv4(string ipString)
        {
            if (String.IsNullOrWhiteSpace(ipString))
            {
                return false;
            }

            string[] splitValues = ipString.Split('.');
            if (splitValues.Length != 4)
            {
                return false;
            }

            byte tempForParsing;

            return splitValues.All(r => byte.TryParse(r, out tempForParsing));
        }
    }
}
