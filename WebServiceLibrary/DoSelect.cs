using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace WebServiceCalls
{
    public class DoSelect
    {
        public string doSelect(string sID, string name)
        {
            int convertSID = Int32.Parse(sID);
            string[] nrAttribs = new string[150];
            nrAttribs[25] = "id";
            nrAttribs[40] = "name";
            string objectHandle = string.Empty;
            CASDServiceReference.USD_WebServiceSoapClient client = new CASDServiceReference.USD_WebServiceSoapClient();
            string doSelectResponse = client.doSelect(convertSID, "nr", "name = '" + name + "'", -1, nrAttribs);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(doSelectResponse);
            string xpath = "UDSObjectList/UDSObject/Handle";
            var nodes = xmlDoc.SelectNodes(xpath);
            foreach (XmlNode childrenNode in nodes)
            {
                objectHandle = childrenNode.InnerText;
                if (String.IsNullOrEmpty(objectHandle))
                    throw new Exception("Object handle not found for " + name);
                else
                    continue;
            }
            
                return objectHandle;
        }
    }
}
