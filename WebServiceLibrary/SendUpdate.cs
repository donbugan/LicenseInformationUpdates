using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebServiceCalls.CASDServiceReference;

namespace WebServiceCalls
{
    class SendUpdate
    {
        public string updateRequest(int convertSID, string objectHandle, string[] attrValues, string[] attributes)
        {
            using (USD_WebServiceSoapClient client = new USD_WebServiceSoapClient())
            {
                string result = client.updateObject(convertSID, objectHandle, attrValues, attributes);
                return result;
            }
        }
    }
}
