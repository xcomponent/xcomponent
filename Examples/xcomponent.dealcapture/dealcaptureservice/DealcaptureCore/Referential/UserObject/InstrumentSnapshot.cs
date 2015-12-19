using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XComponent.Referential.UserObject
{
    [Serializable]
    public class InstrumentSnapshot
    {
        public List<string> Instruments { get; set; }
        
        public InstrumentSnapshot()
        {
            this.Instruments = new List<string>();

            this.Instruments.Add("CL");
            this.Instruments.Add("C");
            this.Instruments.Add("WH");
        }
    }
}
