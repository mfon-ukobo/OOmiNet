using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOmiNet;
public class OomiPropertyAttribute : Attribute
{
	public OomiPropertyAttribute()
	{

	}

	public OomiPropertyAttribute(string name)
	{
		Name = name;
	}

	public string? Name { get; set; }
}
