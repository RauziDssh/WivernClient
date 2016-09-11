using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WivernClient
{
    public class MacData
    {
        public string ip { get; private set; }
        public string mac { get; private set; }

        public MacData(string i,string m)
        {
            this.ip = i;
            this.mac = m;
        }
    }

    public static class MacStore
    {
        public static List<MacData> macList = new List<MacData>();

        public static MacData GetEncodedMacData(MacData md)
        {
            var enc = Encoding.GetEncoding(50220);
            var base64Str = Convert.ToBase64String(enc.GetBytes(md.mac)).Where(v => v != '=').Select(v => v.ToString()).Aggregate((acc, cc) => acc + cc);
            return new MacData(md.ip,base64Str);
        }

        public static string GetEncodedMacAddress(string s)
        {
            var enc = Encoding.GetEncoding(50220);
            var base64Str = Convert.ToBase64String(enc.GetBytes(s)).Where(v => v != '=').Select(v => v.ToString()).Aggregate((acc, cc) => acc + cc);
            return base64Str;
        }
    }
}
