using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossOverClientManagerEntities.Model
{
    public class Command
    {
        [Key]
        public int CommandID { get; set; }
        public string CommandString { get; set; }
        public int OSID { get; set; }
        public string Parameters { get; set; }
        public virtual OSType OSType { get; set; }

    }
}
