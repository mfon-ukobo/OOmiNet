using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

namespace OOmiNet.Tests;
public class Startup
{
	public void ConfigureServices(IServiceCollection services)
	{
		services.AddOomi(c =>
		{
			c.OomiAccessId = "0697011331";
			c.OomiSecret = "77be06f5caaa30f0a123b32463d33a5a";
			c.BaseUrl = "https://biraapi.oomi.co.uk/";
		});
	}
}
