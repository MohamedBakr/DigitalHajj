using DigitalHajj.Models;
using Newtonsoft.Json;
using System;
using System.Net;

namespace DigitalHajj.DataAccess
{
    public class CamlyticsClient
    {
        public CameraEvent[] GetResult(string serverURL)
        {
            try
            {
                var client = new WebClient();
                string result = client.DownloadString(serverURL);
                return JsonConvert.DeserializeObject<CameraEvent[]>(result);
            }
            catch (Exception ex)
            {
                return new CameraEvent[0];
            }

        }
    }
}
