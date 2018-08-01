using DigitalHajj.DataAccess;
using DigitalHajj.Models;
using System;

namespace DigitalHajj.Business
{
    public class CrowdCounterBl
    {
        public CameraEvent[] CountCameraCrowd()
        {
            var client = new CamlyticsClient();
            var result = client.GetResult("http://localhost:48462/v1/json/events?limit=10&order=DESC&timeout=5");
            return result;
        }
    }
}
