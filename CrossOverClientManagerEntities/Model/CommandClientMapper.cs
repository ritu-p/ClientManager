using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossOverClientManagerEntities.Model
{
    public class CommandClientMapper
    {

        public int CommandID { get; set; }
        public int ID { get; set; }
        public string Frequency { get; set; }
        public DateTime ScheduledTime { get; set; }

        public virtual Command Command { get; set; }
        public virtual Client Client { get; set; }

    }
}
