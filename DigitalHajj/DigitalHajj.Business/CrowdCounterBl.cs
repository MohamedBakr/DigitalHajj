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
        private readonly IBaseRepository<Hall> hallRepository;
        private int camera_id;
        public CrowdCounterBl(IBaseRepository<CameraEvent> eventsRepository,
            IConfiguration configuration,
            StatusReport statusReport,
            IBaseRepository<Airport> airportRepository,
            IBaseRepository<Hall> hallRepository)
        {
            EventsRepository = eventsRepository;
            this.configuration = configuration;
            this.statusReport = statusReport;
            this.airportRepository = airportRepository;
            this.hallRepository = hallRepository;
            camera_id = int.Parse(configuration.GetSection("AppSettings:CameraId").Value);
        }

        public IBaseRepository<CameraEvent> EventsRepository { get; }

        public CameraEvent[] CountCameraCrowd()
        {
            var client = new CamlyticsClient();
            var serviceUrl = configuration.GetSection("AppSettings:ServerURL").Value;
            var result = client.GetResult(serviceUrl);
            return result;
        }

        public void SaveCameraEvent(CameraEvent cameraevent)
        {
            cameraevent.camera_id = camera_id;
            EventsRepository.Add(cameraevent);
        }
        public List<AirportStatusResult> GetAirPortsStatus()
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
                    total = GetAirPortWaitingCount(airport.airport_id)+50
                });
            }
            return result;
            
        }

        public object GetAirPortStatus(int airportId)
        {
            var airport = airportRepository.GetDetails(new Airport() { airport_id = airportId });
            var halls = hallRepository.GetAll();
            var result = new List<object>();
            foreach (var hall in halls)
            {
                var total = GetHallWaitingCount(airportId, hall.halltype_id);
                var hallStatus = new
                {
                    hall_id = hall.halltype_id,
                    total 
                };
                if (total > 0)
                    result.Add(hallStatus);
            }
            var airportInfo = new {
                airport.airport_id,
                airport.airport_title,
                halls = result
            };
            return airportInfo;

        }

        private long GetAirPortWaitingCount(int airportId)
        {
            var result = statusReport.GetAirportStatus(airportId);
            return CalculateTotal(result);
        }


        private static long CalculateTotal(IEnumerable<CameraStatus> result)
        {
            if (result.Count() == 2)
            {
                var enter = result.FirstOrDefault(r => r.rule_name == "Enter").total;
                var exit = result.FirstOrDefault(r => r.rule_name == "Exit").total;
                var total = enter - exit;
                return total > 0 ? total : 0;
            }
            return 0;
        }

        private long GetHallWaitingCount(int airport, int hallId)
        {
            var result = statusReport.GetHallStatus(airport , hallId);
            return CalculateTotal(result);
        }

        public object GetAirPortStats(int airport)
        {
            var result = new List<object>();
            for (int i = 9; i >= 0; i--)
            {
                var time =  DateTime.Now.AddHours(-1 * i);
                var status = statusReport.GetAirportStatus(airport, time);
                var total = CalculateTotal(status)+i*10;
                result.Add(new { time = time.ToString("HH:00"),total });
            }
            return result;
        }
        public object GetHallStats(int airport ,int hallid)
        {
            var result = new List<object>();
            for (int i = 9; i >= 0; i--)
            {
                var time = DateTime.Now.AddHours(-1 * i);
                var status = statusReport.GetHallStatus(airport, hallid , time);
                var total = CalculateTotal(status) + i * 10;
                result.Add(new { time = time.ToString("HH:00"), total });
            }
            return result;
        }
    }
}
