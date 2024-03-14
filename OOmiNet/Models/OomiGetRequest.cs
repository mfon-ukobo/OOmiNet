using System.Diagnostics.CodeAnalysis;

namespace OOmiNet.Models;

public class OomiGetRequest
{


	[SetsRequiredMembers]
	public OomiGetRequest(string entityName, string fields = "*")
	{
		EntityName = entityName;
		Fields = fields;
		Criterias = new();
		Logic = "1";
		PageNo = "1";
		PageSize = "20";
	}

	public required string EntityName { get; set; }

	public string Fields { get; set; }

	public List<OomiRequestCriteria> Criterias { get; private set; }

	public string Logic { get; private set; }

	public string PageNo { get; set; }

	public string PageSize { get; set; }

	public void SetCriterias(CriteriaBuilderResult criteriaBuilderResult)
	{
		Criterias = criteriaBuilderResult.Criterias;
		Logic = criteriaBuilderResult.Logic;
	}
}