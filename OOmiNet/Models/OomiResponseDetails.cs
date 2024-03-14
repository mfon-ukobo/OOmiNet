namespace OOmiNet.Models;

public class OomiResponseDetails
{
	public int PageNo { get; set; }

	public int TotalRecords { get; set; }

	public int TotalPages { get; set; }

	public string? MethodName { get; set; }
}
