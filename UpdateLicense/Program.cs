using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using WebServiceCalls;
//using UpdateLicense;

namespace WebServiceCalls
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter writer = File.AppendText(ConfigurationManager.AppSettings["applicationLog"]);
            string updateCIResponse = string.Empty;
            string sIDFromLogin = string.Empty;
            string returnHandle = string.Empty;
            WebService makeWebServiceCall = new WebService();
            LogIn login = new LogIn();
            sIDFromLogin = login.login()[2];
            DoSelect doselect = new WebServiceCalls.DoSelect();
            string[] lines = System.IO.File.ReadAllLines(@"ci_list.csv");
            string[] line = new string[3];
            foreach (string linerow in lines)
            {
                line = linerow.Split(',');
                try
                {
                    returnHandle = doselect.doSelect(sIDFromLogin, line[0]);
                }
                catch (Exception handleNotFoundException)
                {
                    writer.WriteLine(handleNotFoundException.Message);
                }
                writer.Write(DateTime.Now);
                Console.Write(DateTime.Now);
                writer.Write("  ::: ");
                Console.Write("  ::: ");
                writer.WriteLine("The object handle being updated is: " + line[0]);
                Console.WriteLine("The object handle being updated is: " + line[0]);
                updateCIResponse = makeWebServiceCall.UpdateCIs(sIDFromLogin, returnHandle, line[1], line[2]);
                writer.Write(DateTime.Now);
                Console.Write(DateTime.Now);
                writer.Write("  ::: ");
                Console.Write("  ::: ");
                writer.WriteLine("CI " + line[0] + " update result is: " + updateCIResponse);
                Console.WriteLine("CI " + line[0] + " update result is: " + updateCIResponse);
                writer.Flush();
                writer.Close();
            }
            LogOut logout = new LogOut();
            logout.logout(sIDFromLogin);
        }
    }
}
