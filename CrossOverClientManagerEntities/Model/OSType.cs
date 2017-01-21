using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossOverClientManagerEntities.Model
{
   public class OSType
    {
       [Key]
        public int OSID { get; set; }
        public string OSNAme { get; set; }
        public string Version { get; set; }

    }
}
