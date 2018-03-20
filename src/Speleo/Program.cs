﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;

namespace Speleo
{
    /// <summary>
    /// todo
    /// </summary>
    /// <remarks>todo</remarks>     
    public class Program
    {
        /// <summary>
        /// todo
        /// </summary>
        /// <remarks>todo</remarks>             
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseUrls("http://*:5000/")
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
