using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using OOmiNet.Models;

[assembly: InternalsVisibleTo("OOmiNet.Tests")]
namespace OOmiNet;
internal class OomiService : IOomiService
{
	private readonly HttpClient _client;
	private readonly OomiConfiguration _config;
	private readonly ILogger<OomiService> _logger;

	public OomiService(HttpClient client, OomiConfiguration config, ILogger<OomiService> logger)
	{
		client.DefaultRequestHeaders.Add("Signature", GetSignature(DateTime.Now, config.OomiSecret!));
		client.DefaultRequestHeaders.Add("CurrentDateTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
		_client = client;
		_config = config;
		_logger = logger;
	}

	public async Task<OomiResponse<T>> GetApiResponse<T>(OomiGetRequest request) where T : OomiRecord, new()
	{
		try
		{
			string endpoint = "api/oomi/GetEntity";
			var requestJson = JsonConvert.SerializeObject(request);
			var content = new StringContent(requestJson, Encoding.UTF8, MediaTypeNames.Application.Json);
			var response = await _client.PostAsync(endpoint, content);

			response.EnsureSuccessStatusCode();

			var jsonString = await response.Content.ReadAsStringAsync();
			var model = Deserialize<OomiResponse<T>>(jsonString)!;
			return new OomiResponse<T>
			{
				Details = model.Details,
				Error = model.Error,
				Records = model.Records.Select(x => x.TryConvertTo<T>()).ToList()
			};
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "Error retrieving response for {Request}", Serialize(request));
			throw;
		}
	}

	private static string GetSignature(DateTime dateTime, string secretKey)
	{
		var variables = new string[] { dateTime.ToString("yyyy-MM-dd HH:mm:ss") };
		string value = string.Join("\n", variables);
		var secretBytes = Encoding.UTF8.GetBytes(secretKey);
		var valueBytes = Encoding.UTF8.GetBytes(value);

		using var hmac = new HMACSHA256(secretBytes);
		byte[] hash = hmac.ComputeHash(valueBytes);
		string signature = Convert.ToBase64String(hash);
		return signature;
	}

	private string Serialize<T>(T obj)
	{
		return JsonConvert.SerializeObject(obj);
	}

	private T? Deserialize<T>(string json)
	{
		return JsonConvert.DeserializeObject<T>(json);
	}
}
