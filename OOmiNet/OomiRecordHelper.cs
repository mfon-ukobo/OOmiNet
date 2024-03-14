using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using OOmiNet.Models;

namespace OOmiNet;
public static class OomiRecordHelper
{
	public static T TryConvertTo<T>(this OomiRecord record) where T : OomiRecord, new()
	{
		T obj = new();

		// put thisin if we want to copy the dictionary items
		/*foreach (var item in record)
		{
			obj[item.Key] = item.Value;
		}*/

		var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
			.Where(x => x.GetCustomAttribute<OomiPropertyAttribute>() != null)
			.Where(x => x.CanWrite && x.SetMethod != null);

		foreach (var property in properties)
		{
			var value = record.TryGetValue(property.Name, out var valueObj) ? valueObj : null;
			property.SetValue(obj, value);
		}

		return obj;
	}
}
