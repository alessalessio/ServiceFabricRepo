﻿using System;
using System.Collections.Generic;
using System.Fabric;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.ServiceFabric.Services.Communication.AspNetCore;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;

namespace WebCoreStateless4
{
    /// <summary>
    /// The FabricRuntime creates an instance of this class for each service type instance. 
    /// </summary>
    internal sealed class WebCoreStateless4 : StatelessService
    {
        public WebCoreStateless4(StatelessServiceContext context)
            : base(context)
        { }

        /// <summary>
        /// Optional override to create listeners (like tcp, http) for this service instance.
        /// </summary>
        /// <returns>The collection of listeners.</returns>
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            //sidufhisdfhdih
            return new ServiceInstanceListener[]
            {
                new ServiceInstanceListener(serviceContext =>
                    new WebListenerCommunicationListener(serviceContext, "ServiceEndpoint", url =>
                    {
                        ServiceEventSource.Current.ServiceMessage(serviceContext, $"Starting WebListener on {url}");

                        return new WebHostBuilder().UseWebListener()
                                    .ConfigureServices(
                                        services => services
                                            .AddSingleton<StatelessServiceContext>(serviceContext))
                                    .UseContentRoot(Directory.GetCurrentDirectory())
                                    .UseStartup<Startup>()
                                    .UseUrls(url)
                                    .Build();
                    }))
            };
        }
    }
}