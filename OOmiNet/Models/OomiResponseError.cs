namespace OOmiNet.Models;

public class OomiResponseError
{
	public string? ErrorCode { get; set; }

	public string? ErrorDescription { get; set; }

	public bool IsSuccess()
	{
		return ErrorCode == "200";
	}
}
