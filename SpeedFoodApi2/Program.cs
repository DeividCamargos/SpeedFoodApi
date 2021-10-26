﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Server.IISIntegration;
using System.IO;

namespace SpeedFoodApi2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var host = new WebHostBuilder()
            //                .UseKestrel()
            //                .UseContentRoot(Directory.GetCurrentDirectory())
            //                .UseIISIntegration()
            //                .UseStartup<Startup>()
            ////                .Build();
            CreateHostBuilder(args).Build().Run(); 
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
