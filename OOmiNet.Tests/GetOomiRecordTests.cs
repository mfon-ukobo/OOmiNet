using Microsoft.VisualStudio.TestPlatform.TestHost;

using OOmiNet.Models;
using OOmiNet.Tests.Models;

namespace OOmiNet.Tests;

public class GetOomiRecordTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
	private readonly IOomiService _oomiService;

	public GetOomiRecordTests(IOomiService oomiService)
	{
		_oomiService = oomiService;
	}


	[Fact]
	public async Task GetRecord_ShouldBeSuccessful_WhenValidCriteria()
	{
		var username = "richard.spider@yopmail.com";
		var password = "Password@1234";

		var criterias = new OomiCriteriaBuilder(OomiRequestCriteria.Create("LoginUserName", "3", username));
		//criterias.And(OomiRequestCriteria.Create("LoginPassword", "3", password));
		var request = new OomiGetRequest("CONTACT");
		request.SetCriterias(criterias.Build());

		var response = await _oomiService.GetApiResponse<TestOomiRecord>(request);
		var record = response.Records.First();
		var checkUserName = record.LoginUserName;

		Assert.NotNull(response);
		Assert.NotNull(response.Records);
		Assert.True(response.Records.Any());
		Assert.NotNull(checkUserName);
	}
}