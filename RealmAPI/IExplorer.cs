﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace WowDotNet.Explorers
{
    public interface IExplorer : IDisposable
    {
        WebClient WebClient { get; set; }
    }
}
