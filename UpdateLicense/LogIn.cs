using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using WebServiceCalls;

namespace UpdateLicense
{
    public class LogIn
    {
        public string[] login()
        {
            int sID = 0;
            string[] arrayResults = new string[3];
            StreamWriter writer = File.AppendText(ConfigurationManager.AppSettings["applicationLog"]);
            try
            {
                WebServiceCalls.CASDServiceReference.USD_WebServiceSoapClient client = new WebServiceCalls.CASDServiceReference.USD_WebServiceSoapClient();
                sID = client.login(ConfigurationManager.AppSettings["login"], ConfigurationManager.AppSettings["password"]);
                writer.Write(DateTime.Now);
                Console.Write(DateTime.Now);
                writer.Write("  ::: ");
                Console.Write("  ::: ");
                writer.WriteLine("Login to Web Services Successful. SID returned: " + sID);
                Console.WriteLine("Login to Web Services Successful. SID returned: " + sID);
                writer.Flush();
                writer.Close();
                arrayResults[0] = "0";
                arrayResults[1] = "Success";
                arrayResults[2] = sID.ToString();
            }
            catch (Exception errMsg)
            {
                writer.Write(DateTime.Now);
                Console.Write(DateTime.Now);
                writer.Write("  ::: ");
                Console.Write("  ::: ");
                writer.WriteLine("Login to Web Services Unsuccessful. Please investigate error returned: \n" + errMsg.InnerException);
                Console.WriteLine("Login to Web Services Unsuccessful. Please investigate error returned: \n" + errMsg.InnerException);
                writer.Flush();
                writer.Close();
                arrayResults[0] = "1";
                arrayResults[1] = "Failure";
                arrayResults[2] = "-1";
            }

            return arrayResults;
        }
    }
}
