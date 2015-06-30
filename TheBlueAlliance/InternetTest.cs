using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.Threading.Tasks;
using System.IO;

namespace TheBlueAlliance
{
    public class InternetTest
    {
        public static Boolean internetAvailable;
        private static void checkInternet()
        {
            while (true)
            {
                try
                {
                    using (var client = new WebClient())
                    using (Stream stream = client.OpenRead("http://www.google.com"))
                    {
                        internetAvailable = true;
                    }
                }
                catch
                {
                    internetAvailable = false;
                }
                System.Threading.Thread.Sleep(5000);
            }
        }
    }
}
