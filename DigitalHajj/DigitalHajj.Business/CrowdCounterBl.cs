using DigitalHajj.DataAccess;
using DigitalHajj.Models;
using System;

namespace DigitalHajj.Business
{
    public class CrowdCounterBl
    {
        public CrowdCounterBl(IBaseRepository<CameraEvent> eventsRepository)
        {
            EventsRepository = eventsRepository;
        }

        public IBaseRepository<CameraEvent> EventsRepository { get; }

        public CameraEvent[] CountCameraCrowd()
        {
            var client = new CamlyticsClient();
            var result = client.GetResult("http://localhost:48462/v1/json/events?limit=10&order=DESC&timeout=5");
            return result;
        }

        public void SaveCameraEvent(CameraEvent cameraevent)
        {
            EventsRepository.Add(cameraevent);
        }
    }
}
