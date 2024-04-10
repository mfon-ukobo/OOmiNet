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
	/// <summary>
	/// Converts an <see cref="OomiRecord"/> to an object of type <typeparamref name="T"/>
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="record"></param>
	/// <param name="includeDictionaryValues">Set to false for performance reasons</param>
	/// <returns></returns>
	public static T TryConvertTo<T>(this OomiRecord record, bool includeDictionaryValues = false) where T : OomiRecord, new()
	{
		T obj = new();

		if (includeDictionaryValues)
		{
			foreach (var item in record)
			{
				obj[item.Key] = item.Value;
			}
		}

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

	public static Dictionary<string, object?> ToDictionary<T>(this T record) where T : OomiRecord
	{
		var dict = new Dictionary<string, object?>();

		var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
			.Where(x => x.GetCustomAttribute<OomiPropertyAttribute>() != null);

		foreach (var property in properties)
		{
			var value = property.GetValue(record);
			dict.TryAdd(property.Name, value);
		}

		return dict;
	}
}
