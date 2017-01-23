using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrossOverClientManagerEntities.Model;
using Newtonsoft.Json;

namespace CrossoverClientManagerServer.Models
{
    public class CommandResponse
    {

        [JsonProperty("Commandstring")]
        public string Commandstring { get; set; }

        [JsonProperty("OSName")]
        public string OSName { get; set; }
        [JsonProperty("OSVersion")]
        public string OSVersion { get; set; }

        [JsonProperty("Parameters")]
        public string[] parameters { get; set; }
      

        public Command ToCommandObject(OSType osType)
        {
            Command command = new Command() { CommandString = this.Commandstring, OSType = osType, Parameters = String.Join(",", parameters) };
            return command;
        }

        public bool Validate(List<OSType> os, out String errorString)
        {
            errorString = null;
           
            return true;
        }

    }
}