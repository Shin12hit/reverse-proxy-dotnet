﻿// Copyright (c) Microsoft. All rights reserved.

using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Microsoft.Azure.IoTSolutions.ReverseProxy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel(options =>
                {
                    options.AddServerHeader = false;
                })
                .UseLibuv(options => options.ThreadCount = System.Environment.ProcessorCount)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}