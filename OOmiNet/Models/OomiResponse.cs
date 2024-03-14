using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOmiNet.Models;
public class OomiResponse<T>
{
	public OomiResponseDetails? Details { get; set; }

	public OomiResponseError? Error { get; set; }

	public List<T> Records { get; set; } = new();
}
