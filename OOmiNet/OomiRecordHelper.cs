using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using OOmiNet.Models;

namespace OOmiNet;
public class OomiRecordHelper
{
	public T TryConvertTo<T>() where T : OomiRecord, new()
	{
		T obj = new();

		var properties = typeof(T).GetProperties(BindingFlags.Public).Where(x => x.CanWrite);

		foreach (var property in properties)
		{
			var value = obj.TryGetValue(property.Name, out var valueObj) ? valueObj : null;
			property.SetValue(obj, value, null);
		}

		return obj;
	}
}
