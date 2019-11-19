using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using WebServiceCalls;

namespace UpdateLicense
{
    class LogOut
    {
        public void logout(string sID)
        {
            WebServiceCalls.CASDServiceReference.USD_WebServiceSoapClient client = new WebServiceCalls.CASDServiceReference.USD_WebServiceSoapClient();
            int convertSID = Int32.Parse(sID);
            client.logout(convertSID);
            StreamWriter writer = File.AppendText(ConfigurationManager.AppSettings["applicationLog"]);
            writer.Write(DateTime.Now);
            Console.Write(DateTime.Now);
            writer.Write("  ::: ");
            Console.Write("  ::: ");
            writer.WriteLine("Logout from session with SID: " + sID);
            Console.WriteLine("Logout from session with SID: " + sID);
            writer.Flush();
            writer.Close();
        }
    }
}
