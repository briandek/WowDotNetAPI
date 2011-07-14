﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web.Script.Serialization;

namespace WowDotNetAPI.Explorers.Interfaces
{
    public interface IExplorer<T> : IDisposable
    {
        WebClient WebClient { get; set; }
        JavaScriptSerializer JavaScriptSerializer { get; set; }
    }
}
