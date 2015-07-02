using System;
using System.Net;
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
