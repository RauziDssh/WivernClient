using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Net;
using System.Reactive.Linq;
using System.Reactive.Subjects;


namespace WivernClient
{
    public class PingChecker
    {

        Ping pinger;
        string host = "";
        string local = "";

        public bool[] iplist = new bool[300];

        public Subject<IPStatus> DetectIpStream = new Subject<IPStatus>();

        public PingChecker()
        {
            pinger = new Ping();
            string ipaddress = "";
            IPHostEntry ipentry = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in ipentry.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    ipaddress = ip.ToString();
                    break;
                }
            }

            host = ipaddress.Split('.').Take(3).Aggregate((acc, cc) => acc + '.' + cc).ToString() + ".";
            local = ipaddress.Split('.').Skip(3).First();
            //DetectIpStream.Subscribe(v => Console.WriteLine(v));
        }

        public void Ping(int i)
        {
            var address = host + i.ToString();
            var np = new Ping();
            var p = np.Send(address);
            //Console.Write(i);
            var result = p.Status == System.Net.NetworkInformation.IPStatus.Success ? true : false;

            if (iplist[i] != result)
            {
                iplist[i] = result;
                var ipaddress = IPAddress.Parse(address);
                DetectIpStream.OnNext(new IPStatus(ipaddress, result));
                Console.WriteLine("[DEBUG:IP]" + address + p.Status.ToString());
            }
        }

        public async Task StartPingAllAsync(IEnumerable<int> collection)
        {
            Action asyncJob = () =>
            {
                collection
                    .Where(i => Convert.ToInt32(local) != i)
                    .Select(
                        i =>
                        {
                            var address = host + i.ToString();                           
                            var p = pinger.Send(address);
                            //Console.Write(i);
                            var result = p.Status == System.Net.NetworkInformation.IPStatus.Success ? true : false;
                            
                            if (iplist[i] != result)
                            {
                                iplist[i] = result;
                                var ipaddress = IPAddress.Parse(address);
                                DetectIpStream.OnNext(new IPStatus(ipaddress, result));
                                Console.WriteLine("[DEBUG:IP]" + address + p.Status.ToString());
                            }
                            //Console.WriteLine(address + ":" + result);
                            return result;
                        }
                    ).ToArray();
            };

            while (true)
            {
                Console.WriteLine("start");
                await Task.Run(asyncJob);
                Console.WriteLine("end");
            }
        }
    }

    public class IPStatus
    {
        public IPAddress ip { get; private set; }
        public bool connected { get; private set; }

        public IPStatus(IPAddress i, bool b)
        {
            this.ip = i;
            this.connected = b;
        }
    }
}
