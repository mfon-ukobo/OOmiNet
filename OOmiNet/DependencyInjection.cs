using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

namespace OOmiNet;
public static class DependencyInjection
{
	public static IServiceCollection AddOomi(this IServiceCollection services, Action<OomiConfiguration> config)
	{
		var configValues = new OomiConfiguration();
		config.Invoke(configValues);

		services.AddSingleton(configValues);

		services.AddHttpClient<IOomiService, OomiService>(client =>
		{
			client.BaseAddress = new Uri(configValues.BaseUrl!);
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Add("AccessId", configValues.OomiAccessId);
			client.DefaultRequestHeaders.Add("Access-Control-Allow-Headers", "x-requested-with");
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		});

		return services;
	}
}
