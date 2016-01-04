using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XComponent.TradeCapture.TriggeredMethod
{
    public class Mapper
    {
        private Dictionary<int, string> map = new Dictionary<int, string>();
        private List<string> instruments = new List<string>();
        
        public Mapper()
        {
            map.Add(1, "F");
            map.Add(2, "G");
            map.Add(3, "H");
            map.Add(4, "J");
            map.Add(5, "K");
            map.Add(6, "M");
            map.Add(7, "N");
            map.Add(8, "Q");
            map.Add(9, "U");
            map.Add(10, "V");
            map.Add(11, "X");
            map.Add(12, "Z");

            instruments.Add("CL");
            instruments.Add("WH");
            instruments.Add("C");
        }

        public string GetValue(string key, DateTime maturityDate)
        {
            String mapped = key.ToUpper();          
            string suffix = map.First(e => e.Key == maturityDate.Month).Value;
            suffix += maturityDate.Year.ToString().Substring(2, 2);

            return mapped + suffix;
        }

        public void AddValue(string instrument)
        {
            if(!instruments.Contains(instrument))
                instruments.Add(instrument);
        }

        public bool ContainsValue(string instrument)
        {
            return instruments.Contains(instrument) || instruments.Contains(instrument.ToUpper()) || instruments.Contains(instrument.ToLower());
        }
    }
}
