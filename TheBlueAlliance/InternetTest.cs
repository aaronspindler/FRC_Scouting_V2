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
        public static Boolean checkInternet()
        {
            while (true)
            {
                try
                {
                    using (var client = new WebClient())
                    using (Stream stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
                catch
                {

                }
                System.Threading.Thread.Sleep(5000);
            }
        }
    }
}
