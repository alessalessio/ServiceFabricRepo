﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace ClassLibrary
{
    public interface IMyService : IService
    {
        Task<string> HelloWorldAsync();
    }
}
