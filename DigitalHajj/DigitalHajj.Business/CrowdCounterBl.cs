using DigitalHajj.DataAccess;
using DigitalHajj.Models;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System;

namespace DigitalHajj.Business
{
    public class CrowdCounterBl
    {
        private readonly IConfiguration configuration;
        private readonly StatusReport statusReport;
        private readonly IBaseRepository<Airport> airportRepository;
        private int camera_id;
        public CrowdCounterBl(IBaseRepository<CameraEvent> eventsRepository,
            IConfiguration configuration,StatusReport statusReport,IBaseRepository<Airport> airportRepository)
        {
            EventsRepository = eventsRepository;
            this.configuration = configuration;
            this.statusReport = statusReport;
            this.airportRepository = airportRepository;
            camera_id = int.Parse(configuration.GetSection("AppSettings:CameraId").Value);
        }

        public IBaseRepository<CameraEvent> EventsRepository { get; }

        public CameraEvent[] CountCameraCrowd()
        {
            var client = new CamlyticsClient();
            var serviceUrl = configuration.GetSection("AppSettings:SiteURL").Value;
            var result = client.GetResult(serviceUrl);
            return result;
        }

        public void SaveCameraEvent(CameraEvent cameraevent)
        {
            cameraevent.camera_id = camera_id;
            EventsRepository.Add(cameraevent);
        }
        public List<AirportStatusResult> GetAirPortStatus()
        {
            var airports = airportRepository.GetAll();
            var result = new List<AirportStatusResult>();
            foreach (var airport in airports)
            {
               
                result.Add(new AirportStatusResult()
                {
                    airport_id = airport.airport_id,
                    airport_title = airport.airport_title,
                    lat = airport.lat,
                    lng = airport.lng,
                    total = GetWaitingCount(airport.airport_id)
                });
            }
            return result;
            
        }

        private long GetWaitingCount(int airportId)
        {
            var result = statusReport.GetAirportStatus(airportId);
            if(result.Count() == 2)
            {
                var enter = result.FirstOrDefault(r => r.rule_name == "Enter").total;
                var exit = result.FirstOrDefault(r => r.rule_name == "Exit").total;
                var total = enter - exit;
                return total > 0 ? total : 0;
            }
            return 0;
        }
    }
}
