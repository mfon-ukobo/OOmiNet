using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace OOmiNet.Tests;
public class CustomWebApplicationFactory<TProgram>
	: WebApplicationFactory<TProgram> where TProgram : class
{
	protected override void ConfigureWebHost(IWebHostBuilder builder)
	{
		builder.UseStartup<Startup>();
		builder.UseEnvironment("Development");
	}
}