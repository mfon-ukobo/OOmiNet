using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOmiNet.Models;
public class OomiRecord : Dictionary<string, object?>
{
	public string RecordId
	{
		get
		{
			if (TryGetValue("RecordId", out object? recordId))
			{
				return (string?)recordId ?? string.Empty;
			}

			return string.Empty;
		}
		set
		{
			TryAdd("RecordId", value);
		}
	}

	public void SetValue<T>(string key, T? value)
	{
		TryAdd(key, value);
	}
}
