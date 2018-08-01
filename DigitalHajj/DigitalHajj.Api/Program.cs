using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DigitalHajj.Business;
using DigitalHajj.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DigitalHajj.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var counter = new CrowdCounterBl();
            var db = new List<CameraEvent>(); 
            
            while (true)
            {
                var result = counter.CountCameraCrowd();
                int lastIndex = db.Count() ;
                foreach (var item in result)
                {
                    if (db.Any(i => i.event_id == item.event_id) == false)
                        db.Add(item);
                }
                for (; lastIndex < db.Count(); lastIndex++)
                {
                    Console.WriteLine(db[lastIndex].object_id +"->"+ db[lastIndex].type + "-" + db[lastIndex].rule_name);
                }
                
                Thread.Sleep(5000);
            }

            BuildWebHost(args).Run();
            
            
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
