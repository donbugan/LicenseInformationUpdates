using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Web;
using CsvHelper;


namespace WebServiceCalls
{
    public class WebService
    {
        public string UpdateCIs(string sID, string handle, string zLicenseCount, string zAvailLicense)
        {
            CASDServiceReference.USD_WebServiceSoapClient client = new CASDServiceReference.USD_WebServiceSoapClient();
            int convertSID = Int32.Parse(sID);
            string attribName = handle;
            string[] attrVals = new string[4];
            string[] attributes = new string[4];
            attrVals[0] = "license_number";
            attrVals[1] = zLicenseCount;
            attrVals[2] = "zlicense_available";
            attrVals[3] = zAvailLicense;
            string responseText = string.Empty;
            SendUpdate updateMessage = new SendUpdate();
            string updateResponse = updateMessage.updateRequest(convertSID, attribName, attrVals, attributes);
            if (updateResponse.Contains("ErrorCode"))
            {
                responseText = updateResponse;
            }
            else
            {
                responseText = "Update Success.";
            }
            return responseText;
        }
    }
}