using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossOverClientManagerEntities.Model
{
   public class CommandOutput
    {
             public int CommandID { get; set; }
             public int ID { get; set; }
             public string OutputBlob { get; set; }
             public DateTime writeTime { get; set; }

             public virtual Command Command { get; set; }
             public virtual Client Client { get; set; }

    }
}
