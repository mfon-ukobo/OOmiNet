namespace OOmiNet.Models;

public class OomiRequestCriteria
{
	public string? Field { get; private set; }

	public string? Operator { get; private set; }

	public string? Rank { get; private set; }

	public string? Value { get; private set; }

	internal void SetRank(int rank)
	{
		Rank = rank.ToString();
	}

	public static OomiRequestCriteria Create(string field, string @operator, string value)
	{
		return new OomiRequestCriteria
		{
			Field = field,
			Operator = @operator,
			Value = value
		};
	}
}
