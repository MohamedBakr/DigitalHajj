using DigitalHajj.Business;
using DigitalHajj.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Reactive.Linq;
using System.Reactive.Concurrency;

namespace DigitalHajj.Api
{
    public class CameraReaderJob : IHostedService, IDisposable
    {
        private  CrowdCounterBl crowdCounterBl;
        private readonly ILogger<CameraReaderJob> _logger;
        private Timer _timer;

        public IServiceProvider Services { get; }

        public CameraReaderJob(IServiceProvider services, ILogger<CameraReaderJob> logger)
        {
            Services = services;
            this._logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Background Service is starting.");

            events.CollectionChanged += Events_CollectionChanged;
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

   

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Background Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        private ObservableCollection<CameraEvent> events = new ObservableCollection<CameraEvent>();

        public void DoWork(object state)
        {
            
            using (var scope = Services.CreateScope())
            {
                crowdCounterBl = scope.ServiceProvider.GetRequiredService<CrowdCounterBl>();

                while (true)
                {
                    var result = crowdCounterBl.CountCameraCrowd();
                    int lastIndex = events.Count();
                    foreach (var item in result)
                    {
                        if (events.Any(i => i.event_id == item.event_id) == false)
                            events.Add(item);
                    }
                    for (; lastIndex < events.Count(); lastIndex++)
                    {
                        Console.WriteLine(events[lastIndex].object_id + "->" + events[lastIndex].type + "-" + events[lastIndex].rule_name);
                    }

                    Thread.Sleep(5000);
                }
            }
        }

        private void Events_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            foreach (var x in e.NewItems)
            {
                crowdCounterBl.SaveCameraEvent((CameraEvent)x);
            }
        }
    }
}
