using Microsoft.ServiceFabric.Services.Communication.Runtime;
using System;
using System.Collections.Generic;
using System.Fabric;
using System.Fabric.Description;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stateful1
{
    public class HttpCommunicationListener : ICommunicationListener
    {
        private HttpListener httpListener;
        private string publishUri;
        private ServiceContext serviceContext;

        public HttpCommunicationListener(ServiceContext context)
        {
            this.serviceContext = context;
        }

        public void Abort()
        {
            throw new NotImplementedException();
        }

        public Task CloseAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> OpenAsync(CancellationToken cancellationToken)
        {
            EndpointResourceDescription endpoint =
                serviceContext.CodePackageActivationContext.GetEndpoint("WebEndpoint");

            string uriPrefix = $"{endpoint.Protocol}://+:{endpoint.Port}/myapp/";

            this.httpListener = new HttpListener();
            this.httpListener.Prefixes.Add(uriPrefix);
            this.httpListener.Start();

            string uriPublished = uriPrefix.Replace("+", FabricRuntime.GetNodeContext().IPAddressOrFQDN);

            //return Task.FromResult(this.publishUri);
            return Task.FromResult(uriPublished);
        }
    }
}
