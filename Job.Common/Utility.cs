using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Job.Common
{
    public class CommonUtils
    {
        public static string ConcatString(string strtext1, string strtext2, string seperator)
        {
            return string.Concat(strtext1, seperator, strtext2);
        }
        public static string GetIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        public static string GetHostName()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            return host.HostName;
        }
    }
}
