using Microsoft.VisualStudio.TestPlatform.TestHost;

using OOmiNet.Models;
using OOmiNet.Tests.Models;

namespace OOmiNet.Tests;

public class OomiHelperTests
{
	[Fact]
	public void InsertRecord_ShouldCreateDictionary_AllTheTime()
	{
		var request = new TestInsertRecord();
		var dictionary = request.ToDictionary();

		Assert.Equal(request.EntityName, dictionary["EntityName"]);
	}
}