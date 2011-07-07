﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web.Script.Serialization;

namespace WowDotNetAPI.Explorers
{
	public interface IExplorer
	{
		JavaScriptSerializer Serializer { get; set; }
	}
}
