using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using System.Net;
using System.Linq;

namespace WivernClient
{
    static class MACConverter
    {
        [DllImport("iphlpapi.dll", ExactSpelling = true)]
        public static extern int SendARP(UInt32 DestIP, UInt32 SrcIP, [Out] byte[] pMacAddr, ref int PhyAddrLen);

        public static string ConvertToMAC(IPAddress ip)
        {
            byte[] macAddr = new byte[6];
            int lenPhyAddr = 6;
            int hr = SendARP((uint)ip.Address, 0, macAddr, ref lenPhyAddr);
            if (hr != 0)
            {
                Console.WriteLine("MACアドレスの取得に失敗しました。");
                return null;
            }
            else
            {
                Console.WriteLine("MACアドレス：{0,2:X}:{1,2:X}:{2,2:X}:{3,2:X}:{4,2:X}:{5,2:X}",
                    macAddr[0], macAddr[1], macAddr[2], macAddr[3], macAddr[4], macAddr[5]);
                return BitConverter.ToString(macAddr, 0, 6);
            }
        }
    }
}
