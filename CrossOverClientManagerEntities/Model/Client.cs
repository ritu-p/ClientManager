using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossOverClientManagerEntities.Model
{
   public class Client
    {
       [Key]
        public int ID { get; set; }
        public string MachineName { get; set; }
        public int OSID { get; set; }
        public string IPAddress { get; set; }
        public virtual OSType OSType { get; set; }
    }
}
